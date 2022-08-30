using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Julia : MonoBehaviour, IUsableObjects
{
    [SerializeField] Sprite sprite;
    [SerializeField] DialogueScriptable dialogue1;
    [SerializeField] DialogueScriptable dialogue2;

    [SerializeField] FadeBlack fadeImageScript;
    [SerializeField] Shop shop;

    bool firstTime = true;

    public void Action()
    {
        if (firstTime)
        {
            DialogueManager.instance.fillPlayDial(dialogue1.messages, false, sprite);
            firstTime = false;
        }
        else // Buying
        {
            DialogueManager.instance.fillPlayDial(dialogue2.messages, false, sprite);
            DialogueManager.instance.ExecFunc += shop.Open;
            DialogueManager.instance.ExecFunc += delegate()
            {
                Playerscript.instance.allowControl = false;
            };
        }
    }
}
