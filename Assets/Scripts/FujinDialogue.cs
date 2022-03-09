using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FujinDialogue : MonoBehaviour
{
    bool triggered = false;
    public GameObject dialogueObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StopDialogue(Collider2D other)
    {
        triggered = true;
        // collider.GameObject.SetActive(true);
        dialogueObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered)
        StopDialogue(other);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
