﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playerscript : MonoBehaviour
{
    Rigidbody2D _rb;

    public float Speed = 25.0f;
    float horizontal;
    float vertical;
    static public bool allowMovement = true;
    bool fujinDialogueTriggered = false;
    void Awake()
    {
        // DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform.position = Finfor.vector;
    }

    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject menu; 
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown("g") && !menu.activeSelf)
        {
            menu.SetActive(true);
            allowMovement = false;
            Debug.Log(allowMovement);
        }
        else if (Input.GetKeyDown("g") && menu.activeSelf)
        {
            allowMovement = true;
            menu.SetActive(false);
            Debug.Log(allowMovement);
        }

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        if (Input.GetKeyDown("space"))
        {
            RaycastHit2D hit = Physics2D.Raycast(_rb.position + Vector2.up * 0.2f, lookDirection, 1.0f, LayerMask.GetMask("UsableObjects"));
            if (hit.collider != null)
            {
                ChestOpen character = hit.collider.GetComponent<ChestOpen>();
                if (character != null)
                {
                    character.OpenChest();
                }
            }
        }
    }

    public GameObject DialogueBoxPrefab;

    public GameObject SoundObject;
    public GameObject Fading;
    public GameObject backgroundMusic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "DialogueTrigger" && !fujinDialogueTriggered)
        {
            GameObject dialogueObject = Instantiate(DialogueBoxPrefab);
            DialogueBox boxComponent = dialogueObject.GetComponent<DialogueBox>();
            boxComponent.Show(-4, 1, 0);
            fujinDialogueTriggered = true;
        }
        if (other.tag == "EnemyBattle")
        {
            AudioSource sound = SoundObject.GetComponent<AudioSource>();
            StartCoroutine(example(sound));
        }

        IEnumerator example(AudioSource sound)
        {
            sound.Play(0);
            backgroundMusic.GetComponent<AudioSource>().Stop();
            Fading.SetActive(true);
            allowMovement = false;
            // CanvasFade script = Fading.GetComponent<CanvasFade>();
            // script.FadeToWhite();
            yield return new WaitWhile (()=> sound.isPlaying);
            allowMovement = true;
            SceneManager.LoadScene("BattleScene");
        }
    }

    void FixedUpdate()
    {
        if (allowMovement)
        {
            Vector2 position = _rb.position;
            position.x = position.x + Speed * horizontal * Time.deltaTime;
            position.y = position.y + Speed * vertical * Time.deltaTime;

            _rb.MovePosition(position);
        }
    }

}
