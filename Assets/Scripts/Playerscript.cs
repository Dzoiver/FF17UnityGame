﻿using System.Collections;
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
            Debug.LogWarning("More than one instance of CharactersScript found!");
            return;
        }
        instance = this;
    }

    #endregion

    Animator animator;
    Rigidbody2D _rb;

    float Speed = 7.0f;
    float horizontal;
    float vertical;

    public bool allowMovement = true;
    public bool allowControl = true;
    public string lastMap = "";
    public GameObject menu;

    public GameObject DialogueBoxPrefab;
    public GameObject BattleSound;
    public GameObject Fading;
    public GameObject backgroundMusic;
    public GameObject dialogueCanvas;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        if (Input.GetKeyDown("space"))
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBattle")
        {
            AudioSource sound = BattleSound.GetComponent<AudioSource>();
            StartCoroutine(StartBattle(sound));
        }

        IEnumerator StartBattle(AudioSource sound)
        {
            sound.Play(0);
            backgroundMusic.GetComponent<AudioSource>().Stop();
            Fading.SetActive(true);
            allowMovement = false;
            yield return new WaitWhile (()=> sound.isPlaying);
            allowMovement = true;
            SceneManager.LoadScene("BattleScene");
        }
    }
    Vector2 lastPosX; // Last frame position
    public float distance; // Distance travelled since last encounter

    void FixedUpdate()
    {
        if (allowControl)
        {
            Vector2 position = _rb.position;
            lastPosX = position;
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
            Vector2 position = _rb.position;
            if (Vector2.Distance(lastPosX, position) > 25f)
                return;
            distance += Vector2.Distance(lastPosX, position);
        }
    }
}
