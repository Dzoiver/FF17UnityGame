﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHouse : MonoBehaviour
{
    public GameObject destinationPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = destinationPoint.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
