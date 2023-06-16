using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    Canvas canvas;
    public static Menu instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Menu found!");
            return;
        }
        instance = this;
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
