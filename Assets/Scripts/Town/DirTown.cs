using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharactersInBattle;
using Positions;

public class DirTown : MonoBehaviour
{
    public GameObject destinationPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (Playerscript.lastMap == "WM")
        {
            GameObject.FindWithTag("Player").transform.position = destinationPoint.transform.position;
        }
        Playerscript.lastMap = "Town";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
