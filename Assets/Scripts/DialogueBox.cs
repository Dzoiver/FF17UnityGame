using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    float enter;
    public Text text;
    float interval = 0.03f;
    float wait = 0f;
    int pos = 0;
    bool completed = false;
    string message = "Don't come closer or you regret it";
    // Start is called before the first frame update
    void Start()
    {
        // text.text += message.Substring(1, 2);
    }

    public bool Show(float posX, float posY, float posZ)
    {
        transform.Translate(posX, posY, posZ);
        gameObject.SetActive(true);
        // Playerscript p = player.GetComponent<Playerscript>();
        Playerscript.allowMovement = false;
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
                Playerscript.allowMovement = true;
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
