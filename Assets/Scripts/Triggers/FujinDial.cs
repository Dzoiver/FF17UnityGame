using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FujinDial : MonoBehaviour
{
    [SerializeField] Sprite sprtObject;
    [SerializeField] DialogueScriptable dialogue;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        DialogueManager.instance.fillPlayDial(dialogue.messages, false, sprtObject);
        Destroy(gameObject);
    }
}
