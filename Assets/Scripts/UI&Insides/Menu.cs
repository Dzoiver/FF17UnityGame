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
        if (Input.GetKeyDown("g") && !canvas.enabled && Playerscript.instance.allowControl)
        {
            canvas.enabled = true;
            Playerscript.instance.allowControl = false;
        }
        else if (Input.GetKeyDown("g") && canvas.enabled)
        {
            Playerscript.instance.allowControl = true;
            canvas.enabled = false;
        }
    }
}
