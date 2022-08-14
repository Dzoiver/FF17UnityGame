using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Julia : MonoBehaviour, IUsableObjects
{
    [SerializeField] Sprite sprite;
    [SerializeField] DialogueScriptable dialogue1;
    [SerializeField] DialogueScriptable dialogue2;

    bool firstTime = true;

    public void Action()
    {
        if (firstTime)
        {
            DialogueManager.instance.fillPlayDial(dialogue1.messages, false, sprite);
            firstTime = false;
        }
        else
        {
            DialogueManager.instance.fillPlayDial(dialogue2.messages, false, sprite);
            firstTime = false;
        }
    }
}
