using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptConversation : MonoBehaviour
{
    [SerializeField] Sprite sprtObject;
    [SerializeField] Sprite villagerSprite;
    [SerializeField] GameObject canvas;
    [SerializeField] DialogueScriptable dialogue1;
    [SerializeField] DialogueScriptable dialogue2;
    bool checkForFinish = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        DialogueManager.instance.fillPlayDial(dialogue1.messages, false, sprtObject);
        checkForFinish = true;
    }
    void Update()
    {
        if (checkForFinish && !DialogueManager.instance.Play)
        {
            DialogueManager.instance.fillPlayDial(dialogue2.messages, false, villagerSprite);
            Destroy(gameObject);
            checkForFinish = false;
        }
    }
}
