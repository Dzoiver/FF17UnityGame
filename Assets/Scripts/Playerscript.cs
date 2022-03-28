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

    Animator animator;
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
        animator = GetComponent<Animator>();
    }
    private SpriteRenderer _renderer;
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

    public GameObject DialogueBoxPrefab;

    public GameObject SoundObject;
    public GameObject Fading;
    public GameObject backgroundMusic;

    public GameObject dialogueCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.name == "DialogueTrigger" && !fujinDialogueTriggered)
        // {
        //     GameObject dialogueObject = Instantiate(DialogueBoxPrefab, dialogueCanvas.transform);
        //     DialogueBox boxComponent = dialogueObject.GetComponent<DialogueBox>();
        //     boxComponent.Show();
        //     fujinDialogueTriggered = true;
        // }
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
    Vector2 lastPosX;
    float newPosX;
    public float distance;

    void FixedUpdate()
    {
        if (allowMovement)
        {
            Vector2 position = _rb.position;
            lastPosX = position;
            position.x = position.x + Speed * horizontal * Time.deltaTime;
            position.y = position.y + Speed * vertical * Time.deltaTime;
            _rb.MovePosition(position);
        }
    }

    void LateUpdate()
    {
        Vector2 position = _rb.position;
        newPosX = position.x;
        distance += Vector2.Distance(lastPosX, position);
        Debug.Log(distance);
    }

}
