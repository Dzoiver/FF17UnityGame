using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FujinDial : MonoBehaviour
{
    public Sprite sprtObject;
    public GameObject canvas;
    public GameObject dialogueBox;
    List<string> list = new List<string>();
    string message1 = "Hey. Have you been fishing again?";
    string message2 = "You seem tired. You should take a rest at home.";
    // Start is called before the first frame update
    void Start()
    {
        list.Add(message1);
        list.Add(message2);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject dial = Instantiate(dialogueBox, canvas.transform);
        Dialogue script = dial.GetComponent<Dialogue>();
        script.fillPlayDial(list, false, sprtObject);
        Destroy(gameObject);
    }
    void Update()
    {
    }
}
