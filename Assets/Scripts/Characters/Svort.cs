using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CharactersInBattle;

public class Svort : MonoBehaviour, IBattle
{
    public GameObject SvortPrefab;
    float Speed = 4f;
    float timeMoving = 0.3f;
    float currentTimeMoving = 0f;
    Vector2 lastPosX;
    float newPosX;
    float distance = 0f;
    Rigidbody2D _rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Finfor.SvortStarted = true;
        Destroy(gameObject);
        Finfor.startVector = transform.position;
        Finfor.enemyListPrefab.Add(SvortPrefab);
        Finfor.enemyListPrefab.Add(SvortPrefab);
    }
    private int index;
        public int Index {
        get { return Index; }
        set { Index = value; }
    }

    private bool stepUp;
    public bool StepUp {
        get { return stepUp; }
        set { stepUp = value; }
    }
    private bool backup;
    public bool Backup {
        get { return backup; }
        set { backup = value; }
    }


    private float hp = 20f;
    private float damage = 10f;

    public float Hp {
        get { return hp; }
        set { hp = value; }
    }

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
        DontDestroyOnLoad(this);
        else if (Finfor.SvortStarted)
        Destroy(gameObject);
    }

    public float Damage {
        get { return damage; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {   
            Characters.enemies--;
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (stepUp && currentTimeMoving < timeMoving)
        {
            Debug.Log("moved forward");
            currentTimeMoving += Time.deltaTime;
            Vector2 position = _rb.position;
            // lastPosX = position;
            position.x = position.x + Speed * Time.deltaTime;
            _rb.MovePosition(position);
            // Vector2 position1 = _rb.position;
            // newPosX = position1.x;
            // if (currentTimeMoving > timeMoving)
            // stepUp = false;
            // distance += Vector2.Distance(lastPosX, position1);
        }
        else if (stepUp)
        {
            Debug.Log("stop moving forward");
            stepUp = false;
            currentTimeMoving = 0f;
        }

        if (backup && currentTimeMoving < timeMoving)
        {
            currentTimeMoving += Time.deltaTime;
            Debug.Log("moved back");
            Vector2 position = _rb.position;
            lastPosX = position;
            position.x = position.x + Speed * Time.deltaTime * -1;
            _rb.MovePosition(position);
            // Vector2 position1 = _rb.position;
            // newPosX = position1.x;
            // if (currentTimeMoving > timeMoving)
            // stepUp = false;
            // distance += Vector2.Distance(lastPosX, position1);
        }
        else if (backup)
        {
            Debug.Log("stop moving back");
            backup = false;
            currentTimeMoving = 0f;
        }
    }

    public void modifyHP()
    {
        Debug.Log("hp rip");
    }

    public float getHP()
    {
        return hp;
    }
        public float getDamage()
    {
        return damage;
    }

    public float Attack(IBattle target)
    {
        return Damage;
    }

    public void Turn(IBattle target)
    {
        
        target.Hp -= Damage;
    }
}
