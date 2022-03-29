using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptConversation : MonoBehaviour
{
    public Sprite sprtObject;
    public Sprite villagerSprite;
    public GameObject canvas;
    public GameObject dialogueBox;
    bool checkForFinish = false;
    List<string> list = new List<string>();
    GameObject dial;
    string message1 = "What? I'll go there by myself if no one comes with me.";
    // Start is called before the first frame update
    void Start()
    {
        list.Add(message1);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        dial = Instantiate(dialogueBox, canvas.transform);
        Dialogue script = dial.GetComponent<Dialogue>();
        script.fillPlayDial(list, false, sprtObject);
        checkForFinish = true;
    }
    void Update()
    {
        if (dial == null && checkForFinish)
        {
            string message1 = "It's reckless, Pete. You're get killed alone.";
            List<string> list = new List<string>();
            list.Add(message1);
            GameObject dial = Instantiate(dialogueBox, canvas.transform);
            Dialogue script = dial.GetComponent<Dialogue>();
            script.fillPlayDial(list, false, villagerSprite);
            Destroy(gameObject);
            checkForFinish = false;
        }
    }
}
