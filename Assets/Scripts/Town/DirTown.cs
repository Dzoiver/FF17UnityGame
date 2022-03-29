using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharactersInBattle;
using Positions;

public class DirTown : MonoBehaviour
{
    public GameObject destinationPoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (Playerscript.lastMap == "WM")
        {
            GameObject.FindWithTag("Player").transform.position = destinationPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
