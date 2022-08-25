using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour
{
    #region Singleton
    public static InfoBox instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InfoBox found!");
            return;
        }
        instance = this;
    }
    #endregion
    [SerializeField] Text textField;
    [SerializeField] GameObject canvasObject;

    float deathTime = 2.0f;
    float currentTime = 0f;
    bool timerDeath = false;

    public void Display(string text)
    {
        textField.text = text;
        canvasObject.SetActive(true);
        timerDeath = true;
    }
    public void Ask(string text)
    {
        Playerscript.instance.allowControl = false;
        textField.text = text;
        canvasObject.SetActive(true);
    }
    public void Clear()
    {
        canvasObject.SetActive(false);
    }
    void Update()
    {
        if (!timerDeath)
            return;
        currentTime += Time.deltaTime;

        if (currentTime > deathTime)
        {
            canvasObject.SetActive(false);
            currentTime = 0f;
        }
    }
}
