using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour, IUsableObjects
{
    [SerializeField] GameObject chestObject;
    ChestOpen chestScript;
    [SerializeField] Sprite sprite;
    [SerializeField] DialogueScriptable dialogue1;
    [SerializeField] DialogueScriptable dialogue2;
    [SerializeField] DialogueScriptable dialogue3;
    [SerializeField] DialogueScriptable dialogue4;
    [SerializeField] DialogueScriptable dialogue5;
    bool firstTime = true;
    bool secondTime = true;
    bool secondTimeOpened = false;

    void Start()
    {
        chestScript = chestObject.GetComponent<ChestOpen>();
    }
    public void Action()
    {
        if (firstTime && !chestScript.opened)
        {
            DialogueManager.instance.fillPlayDial(dialogue1.messages, false, sprite);
            firstTime = false;
        }
        else if (secondTime && !chestScript.opened)
        {
            DialogueManager.instance.fillPlayDial(dialogue2.messages, false, sprite);
            secondTime = false;
        }
        else if (!secondTime && !chestScript.opened)
        {
            DialogueManager.instance.fillPlayDial(dialogue3.messages, false, sprite);
        }
        else if (chestScript.opened && !secondTimeOpened)
        {
            DialogueManager.instance.fillPlayDial(dialogue4.messages, false, sprite);
            secondTimeOpened = true;
        }
        else if (chestScript.opened && secondTimeOpened)
        {
            DialogueManager.instance.fillPlayDial(dialogue5.messages, false, sprite);
        }
    }
}
