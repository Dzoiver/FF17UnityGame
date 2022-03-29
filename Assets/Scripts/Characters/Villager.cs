using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour, IUsableObjects
{
    public GameObject dialogueBox;
    public GameObject canvas;
    public GameObject chestObject;
    ChestOpen chestScript;
    public Sprite sprite;
    bool firstTime = true;
    bool secondTime = true;
    bool secondTimeOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        chestScript = chestObject.GetComponent<ChestOpen>();
    }
    public void Action()
    {
        if (firstTime && !chestScript.opened)
        {
            string message1 = "Do you wanna get some free stuff?";
            string message2 = "Go ahead and check this chest over here.";
            List<string> list = new List<string>();
            list.Add(message1);
            list.Add(message2);
            GameObject dial = Instantiate(dialogueBox, canvas.transform);
            Dialogue script = dial.GetComponent<Dialogue>();
            script.fillPlayDial(list, false, sprite);
            firstTime = false;
        }
        else if (secondTime && !chestScript.opened)
        {
            string message1 = "You'll ask why is a chest there?";
            string message2 = "There is other guy which brought it here.";
            string message3 = "But it was empty until someone put something in it.";
            List<string> list = new List<string>();
            list.Add(message1);
            list.Add(message2);
            list.Add(message3);
            GameObject dial = Instantiate(dialogueBox, canvas.transform);
            Dialogue script = dial.GetComponent<Dialogue>();
            script.fillPlayDial(list, false, sprite);
            secondTime = false;
        }
        else if (!secondTime && !chestScript.opened)
        {
            string message1 = "Come on. Just check it already.";
            List<string> list = new List<string>();
            list.Add(message1);
            GameObject dial = Instantiate(dialogueBox, canvas.transform);
            Dialogue script = dial.GetComponent<Dialogue>();
            script.fillPlayDial(list, false, sprite);
        }
        else if (chestScript.opened && !secondTimeOpened)
        {
            string message1 = "Hehehe. How do you like the present?";
            List<string> list = new List<string>();
            list.Add(message1);
            GameObject dial = Instantiate(dialogueBox, canvas.transform);
            Dialogue script = dial.GetComponent<Dialogue>();
            script.fillPlayDial(list, false, sprite);
            secondTimeOpened = true;
        }
        else if (chestScript.opened && secondTimeOpened)
        {
            string message1 = "I knew you'll like it.";
            List<string> list = new List<string>();
            list.Add(message1);
            GameObject dial = Instantiate(dialogueBox, canvas.transform);
            Dialogue script = dial.GetComponent<Dialogue>();
            script.fillPlayDial(list, false, sprite);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
