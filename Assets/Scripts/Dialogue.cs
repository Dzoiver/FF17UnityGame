using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    int stringAmount = 0;
    string messageText = "";
    bool canMove = false;
    Sprite portrait = null;
    List<string> messagesList;
    string name = "";
    public GameObject canvas;
    GameObject dialgs;
    GameObject spriteObject;
    bool completed;
    Text textMessage;
    float interval = 0.03f;
    float wait = 0f;
    int pos = 0;
    bool play = false;


    string path = "DialogueBox";

    void Start()
    {
        textMessage = GetComponentInChildren<Text>();
    }

    // public Dialogue(List<string> giveList, bool movable, GameObject sprtObject)
    // {
    //     canMove = movable;
    //     messagesList = giveList;
    //     stringAmount = giveList.Count;
    // }
    // public void PlayDialogue()
    // {
    //     GameObject graphicPrefab = Resources.Load(path) as GameObject;
    //     canvas = GameObject.FindWithTag("Canvas1");
    //     dialgs = Instantiate(graphicPrefab, canvas.transform);
    //     textMessage = graphicPrefab.GetComponent<Text>();
    //     messageText = messagesList[0];
    //     if (!canMove)
    //     Playerscript.allowMovement = false;

    //     play = true;
    // }

    public void fillPlayDial(List<string> list, bool movable)
    {
        messagesList = list;
        messageText = messagesList[0];
        if (!movable)
        Playerscript.allowMovement = false;
        play = true;
    }
    void Update()
    {
        if (!play)
        return;
        DrawText();
    }

    public void DrawText()
    {
        if (Input.GetKeyDown("space"))
        {
            if (completed)
            {
                messagesList.RemoveAt(0);
                if (messagesList.Count == 0)
                {
                    Destroy(gameObject);
                    Playerscript.allowMovement = true;
                }
                else
                {
                    messageText = messagesList[0];
                    textMessage.text = "";
                    pos = 0;
                }
            }
            else
            {
                completed = true;
            }
        }

        wait += Time.deltaTime;
        if (wait > interval && pos < messageText.Length)
        {
            textMessage.text += messageText.Substring(pos, 1);
            pos++;
            wait = 0f;
        }
        else if (pos >= messageText.Length)
        {
            completed = true;
        }
    }
}
