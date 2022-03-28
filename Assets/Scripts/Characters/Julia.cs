using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Julia : MonoBehaviour, IUsableObjects
{
    bool firstTime = true;
    public GameObject dialogueBox;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void Action()
    {
        if (firstTime)
        {
            string message1 = "Greetings! Do you wanna buy something?";
            string message2 = "I sell potions, armor and weapons";
            List<string> list = new List<string>();
            list.Add(message1);
            list.Add(message2);
            GameObject dial = Instantiate(dialogueBox, canvas.transform);
            Dialogue script = dial.GetComponent<Dialogue>();
            script.fillPlayDial(list, false);
            firstTime = false;
        }
        else
        {
            string message1 = "Buying?";
            List<string> list = new List<string>();
            list.Add(message1);
            GameObject dial = Instantiate(dialogueBox, canvas.transform);
            Dialogue script = dial.GetComponent<Dialogue>();
            script.fillPlayDial(list, false);
            firstTime = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
