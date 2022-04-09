using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    Canvas canvas;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown("g") && !canvas.enabled)
        {
            canvas.enabled = true;
            // allowMovement = false;
        }
        else if (Input.GetKeyDown("g") && canvas.enabled)
        {
            // allowMovement = true;
            canvas.enabled = false;
        }
    }
}
