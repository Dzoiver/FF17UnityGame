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
    public bool opened = false;

    public Item item;
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
        if (!opened)
        {
        gameObject.GetComponent<SpriteRenderer>().sprite = openChestSprite;
        
        GameObject infoBox = Instantiate(infoBoxPrefab, dialogueCanvas.transform);
        InfoBox infoBoxScript = infoBox.GetComponent<InfoBox>();
        GameObject textObject = GameObject.Find("TextInfo");
        Text text1 = textObject.GetComponent<Text>();
        
        text1.text = "You got " + item.name;
        opened = true;

        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play();

        
        Inventory.instance.Add(item);
        }
        // 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
