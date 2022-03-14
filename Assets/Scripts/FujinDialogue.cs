using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FujinDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Finfor.fujinStarted)
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hello i'm a dialogue");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
