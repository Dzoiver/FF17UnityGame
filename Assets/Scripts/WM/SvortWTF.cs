using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvortWTF : MonoBehaviour
{
    public Sprite sprtObject;
    public GameObject canvas;
    public GameObject dialogueBox;
    public GameObject svort;
    List<string> list = new List<string>();
    GameObject dial;
    string message1 = "Huh?";
    bool fadeSprite = false;
    float fadeTime = 1.5f;
    SpriteRenderer svortSprite;
    float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (Finfor.svortInWMSeen)
        {
            Destroy(gameObject);
            Destroy(svort);
        }
        list.Add(message1);
        svortSprite = svort.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        dial = Instantiate(dialogueBox, canvas.transform);
        Dialogue script = dial.GetComponent<Dialogue>();
        script.fillPlayDial(list, false, sprtObject);
        fadeSprite = true;
        Finfor.svortInWMSeen = true;
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
                Debug.Log(tempColor.a);
            }
            else
            {
                Destroy(gameObject);
                fadeSprite = false;
            }
        }
    }
}
