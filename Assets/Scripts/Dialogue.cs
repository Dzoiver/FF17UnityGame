using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    int stringAmount = 0;
    string messageText = "";
    bool canMove = false;
    Image portrait = null;
    List<string> messagesList;
    string name = "";
    public GameObject canvas;
    GameObject dialgs;
    Sprite spriteObject;
    bool completed;
    Text textMessage;
    float interval = 0.03f;
    float wait = 0f;
    int pos = 0;
    bool play = false;
    bool destroyEnd;


    string path = "DialogueBox";

    void Start()
    {
        textMessage = GetComponentInChildren<Text>();
    }

    public void fillPlayDial(List<string> list, bool movable, Sprite spriteIm)
    {
        messagesList = list;
        messageText = messagesList[0];
        if (!movable)
        Playerscript.allowControl = false;
        play = true;
        if (spriteIm != null)
        {
            portrait = GameObject.FindWithTag("Portrait").GetComponent<Image>();
            portrait.sprite = spriteIm;
        }
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
                    Playerscript.allowControl = true;
                    play = false;
                    return;
                }
                else
                {
                    messageText = messagesList[0];
                    textMessage.text = "";
                    pos = 0;
                    completed = false;
                }
            }
            else if (!completed)
            {
                completed = true;
            }
        }

        wait += Time.deltaTime;
        if (wait > interval && pos < messageText.Length && !completed)
        {
            textMessage.text += messageText.Substring(pos, 1);
            pos++;
            wait = 0f;
        }
        else if (pos >= messageText.Length && !completed)
        {
            completed = true;
        }
        else if (completed && pos < messageText.Length)
        {
            textMessage.text = messagesList[0];
        }
    }
}
