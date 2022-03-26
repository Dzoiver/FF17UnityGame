using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour, IUsableObjects
{
    // Start is called before the first frame update
    public Sprite openChestSprite;
    public GameObject infoBoxPrefab;
    public GameObject dialogueCanvas;

    void Start()
    {
    }

    // public void OpenChest()
    // {
    //     gameObject.GetComponent<SpriteRenderer>().sprite = openChestSprite;
        
    //     GameObject infoBox = Instantiate(infoBoxPrefab, dialogueCanvas.transform);
    //     InfoBox infoBoxScript = infoBox.GetComponent<InfoBox>();
    //     // infoBoxScript.Display();
    // }

    public void Action()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = openChestSprite;
        
        GameObject infoBox = Instantiate(infoBoxPrefab, dialogueCanvas.transform);
        InfoBox infoBoxScript = infoBox.GetComponent<InfoBox>();
        GameObject textObject = GameObject.Find("TextInfo");
        Text text1 = textObject.GetComponent<Text>();
        
        text1.text = "You got Potion";
        // 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
