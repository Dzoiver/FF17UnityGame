using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMDir : MonoBehaviour
{
    public GameObject destinationPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (Playerscript.lastMap == "Crypt")
        {
            GameObject.FindWithTag("Player").transform.position = destinationPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
