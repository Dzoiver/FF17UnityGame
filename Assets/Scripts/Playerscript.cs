using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playerscript : MonoBehaviour
{
    Rigidbody2D _rb;

    public float Speed = 7.0f;
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
        _renderer = GetComponent<SpriteRenderer>();
    }
    private SpriteRenderer _renderer;
    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject menu; 
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = true;
        }   

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

    public GameObject dialogueCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "DialogueTrigger" && !fujinDialogueTriggered)
        {
            GameObject dialogueObject = Instantiate(DialogueBoxPrefab, dialogueCanvas.transform);
            DialogueBox boxComponent = dialogueObject.GetComponent<DialogueBox>();
            boxComponent.Show();
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
