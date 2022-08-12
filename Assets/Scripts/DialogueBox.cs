using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public Text text;
    float interval = 0.03f;
    float wait = 0f;
    int pos = 0;
    bool completed = false;
    string message = "Hey. Have you been catching fish again? You seem tired. You should take a rest at home";
    // Start is called before the first frame update
    void Start()
    {
    }

    public bool Show()
    {
        gameObject.SetActive(true);
        Playerscript.instance.allowMovement = false;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (completed)
            {
                Destroy(gameObject);
                Playerscript.instance.allowMovement = true;
            }
            else
            {
                completed = true;
                text.text = message;
            }
        }

        wait += Time.deltaTime;
        if (wait > interval && pos < message.Length && !completed)
        {
            text.text += message.Substring(pos, 1);
            pos++;
            wait = 0f;
        }
        else if (pos >= message.Length)
        {
            completed = true;
        }
    }
}
