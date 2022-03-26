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
    string message = "Hey. Have you been catching fish again? You seem tired. You should take a rest at home";
    // Start is called before the first frame update
    void Start()
    {
        // text.text += message.Substring(1, 2);
    }

    public bool Show()
    {
        // transform.Translate(posX, posY, posZ);
        // Vector2 temp = transform.position;
        // temp.x = 200;
        // temp.y = 120;
        // Debug.Log(temp.x);
        // transform.position = temp;
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
