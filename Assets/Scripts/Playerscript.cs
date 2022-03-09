using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerscript : MonoBehaviour
{
    Rigidbody2D _rb;

    public float Speed = 25.0f;
    float horizontal;
    float vertical;
    float enter;
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
        // transform.position = fInfo.playerVector;
        Debug.Log("start pos = " + transform.position);
    }

    public GameObject menu; 
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        enter = Input.GetAxis("Submit");

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "fightStartTrigger") // Change to battle scene when approaching fujin
            GoToBattle();

        if (other.name == "DialogueTrigger" && !fujinDialogueTriggered)
        {
            if (!Finfor.isFujin)
            return;
            GameObject dialogueObject = Instantiate(DialogueBoxPrefab);
            DialogueBox boxComponent = dialogueObject.GetComponent<DialogueBox>();
            boxComponent.Show(-4, 1, 0);
            fujinDialogueTriggered = true;
        }
    }

    void StopDialogue(Collider2D collider)
    {
    }

    void GoToBattle()
    {
        if (!Finfor.isFujin)
        return;
        Finfor.isFujin = false;
        Finfor.vector = transform.position;
        Debug.Log("update pos = " + transform.position);
        SceneManager.LoadScene("FujinBattle");
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
