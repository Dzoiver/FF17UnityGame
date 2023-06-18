using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvortWTF : MonoBehaviour, IUsableObjects
{
    [SerializeField] Sprite sprtObject;
    [SerializeField] GameObject svort;
    [SerializeField] DialogueScriptable dialogue;
    bool fadeSprite = false;
    float fadeTime = 1.5f;
    SpriteRenderer svortSprite;
    float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        svortSprite = svort.GetComponent<SpriteRenderer>();
        if (Finfor.instance == null)
            return;
        if (Finfor.instance.svortInWMSeen)
        {
            Destroy(gameObject);
            Destroy(svort);
        }
    }

    public void Action()
    {
        DialogueManager.instance.fillPlayDial(dialogue.messages, false, sprtObject);
        fadeSprite = true;
        if (Finfor.instance != null)
            Finfor.instance.svortInWMSeen = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (fadeSprite)
        {
            currentTime += Time.deltaTime;
            if (currentTime < fadeTime)
            {
                Color tempColor = svortSprite.color;
                tempColor.a -= Time.deltaTime / fadeTime; // 1 => 0
                svortSprite.color = tempColor;
            }
            else
            {
                Destroy(gameObject);
                fadeSprite = false;
            }
        }
    }
}
