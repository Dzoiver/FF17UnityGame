using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Button button;
    // Start is called before the first frame update
    void Start()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }

    public void Open()
    {
        panel.SetActive(true);
    }

    public void Close()
    {
        panel.SetActive(false);
        Playerscript.instance.allowControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
