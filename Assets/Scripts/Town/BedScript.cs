using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedScript : MonoBehaviour, IUsableObjects
{
    public GameObject dialogueCanvas;
    public GameObject infoBoxPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void Action()
    {
        GameObject infoBox = Instantiate(infoBoxPrefab, dialogueCanvas.transform);
        GameObject textInfo = GameObject.Find("TextInfo");
        // GameObject yesObject = GameObject.Find("YesButton");
        // yesObject.SetActive(true);
        // GameObject noObject = Text.Find("NoButton");
        // noObject.SetActive(true);
        Text text1 = textInfo.GetComponent<Text>();
        text1.text = "Take a rest?";
        // InfoBox infoBoxScript = infoBox.GetComponent<InfoBox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
