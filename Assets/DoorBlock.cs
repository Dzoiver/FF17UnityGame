using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlock : MonoBehaviour, IUsableObjects
{
    [SerializeField] DialogueScriptable dialogue1;
    [SerializeField] Sprite sprite;
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
