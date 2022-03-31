using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMDir : MonoBehaviour
{
    public GameObject destinationPoint;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        Playerscript.allowControl = false;
        StartCoroutine(waitTime());
        if (Playerscript.lastMap == "Crypt")
        {
            GameObject.FindWithTag("Player").transform.position = destinationPoint.transform.position;
        }
    }

    IEnumerator waitTime()
    {
        FadeBlack script = image.GetComponent<FadeBlack>();
        script.FadeOut(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.allowControl = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
