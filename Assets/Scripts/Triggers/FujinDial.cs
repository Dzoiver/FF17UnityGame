using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FujinDial : MonoBehaviour
{
    public GameObject sprtObject;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        string message1 = "Hey. Have you been fishing again?";
        string message2 = "You seem tired. You should take a rest at home";
        List<string> list = new List<string>();
        list.Add(message1);
        list.Add(message2);
        Dialogue dial = new Dialogue(list, false, sprtObject);
        dial.PlayDialogue();
    }
}
