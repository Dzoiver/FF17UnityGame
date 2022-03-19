using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite openChestSprite;
    public GameObject infoBoxPrefab;
    public GameObject dialogueCanvas;

    void Start()
    {
    }

    public void OpenChest()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = openChestSprite;
        
        GameObject infoBox = Instantiate(infoBoxPrefab, dialogueCanvas.transform);
        InfoBox infoBoxScript = infoBox.GetComponent<InfoBox>();
        // infoBoxScript.Display();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
