using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBlock : MonoBehaviour, IUsableObjects
{
    [SerializeField] DialogueScriptable dialogue1;
    [SerializeField] Sprite sprite;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    public void Action()
    {
        DialogueManager.instance.fillPlayDial(dialogue1.messages, false, sprite);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
