using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerCrayTalk : MonoBehaviour, IUsableObjects
{
    [SerializeField] Sprite sprite;
    [SerializeField] DialogueScriptable dialogue1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Action()
    {
        DialogueManager.instance.fillPlayDial(dialogue1.messages, false, sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
