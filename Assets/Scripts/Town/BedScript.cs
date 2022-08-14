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
        Instantiate(infoBoxPrefab, dialogueCanvas.transform);
        GameObject textInfo = GameObject.Find("TextInfo");
        Text text1 = textInfo.GetComponent<Text>();
        text1.text = "Take a rest?";
    }
}
