using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public interface IUsableObjects
{
    void Action();
}

public class Playerscript : MonoBehaviour
{
    #region Singleton
    public static Playerscript instance;

    void Awake()
    {
        if (instance != null)
        {
            DontDestroyOnLoad(this);
            Debug.LogWarning("More than one instance of Playerscript found!");
            return;
        }
        instance = this;
    }

    #endregion

    Animator animator;
    Rigidbody2D _rb;

    private float Speed = 7.0f;
    private float horizontal;
    private float vertical;

    private int money = 300;

    public void TakeMoney(int amount)
    {
        if (amount < money)
            money -= amount;
        else
            money = 0;
    }

    public void GiveMoney(int amount)
    {
        money += amount;
    }

    public bool allowControl = true;

    void Start()
    {
        lastPosX = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (CameraScript.instance != null)
            CameraScript.instance.FindPlayer(gameObject);
    }
    Vector2 lookDirection = new Vector2(1, 0);

    // Update is called once per frame
    void Update()
    {
        if (!allowControl)
        return;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown("space") && !DialogueManager.instance.Play)
        {
            RaycastHit2D hit = Physics2D.Raycast(_rb.position + Vector2.up * 0.2f, lookDirection, 1.0f, LayerMask.GetMask("UsableObjects"));
            
            if (hit.collider != null)
            {
                IUsableObjects object1 = hit.collider.GetComponent<IUsableObjects>();
                if (object1 != null)
                {
                    object1.Action();
                }
            }
        }
    }
    private Vector2 lastPosX; // Last frame position
    public float dangerDistance; // Distance travelled since last encounter

    void FixedUpdate()
    {
        lastPosX = _rb.position;
        if (allowControl)
        {
            Vector2 position = _rb.position;
            position.x = position.x + Speed * horizontal * Time.deltaTime;
            position.y = position.y + Speed * vertical * Time.deltaTime;
            _rb.MovePosition(position);
        }
        if (!allowControl)
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void LateUpdate()
    {
        CalcDistance();
    }
    void CalcDistance()
    {
        if (allowControl)
        {
            dangerDistance += Vector2.Distance(lastPosX, _rb.position);
        }
    }
}
