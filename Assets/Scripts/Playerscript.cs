using System.Collections;
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

    public GameObject menu; 
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

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
        // if (horizontal || vertical > 0)
        // {
        //     checkForEnc();
        // }

    }

    public GameObject DialogueBoxPrefab;

    public GameObject SoundObject;
    public GameObject Fading;

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
            Fading.SetActive(true);
            allowMovement = false;
            // CanvasFade script = Fading.GetComponent<CanvasFade>();
            // script.FadeToWhite();
            yield return new WaitWhile (()=> sound.isPlaying);
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
