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
        Playerscript.instance.allowControl = false;
        StartCoroutine(waitTime());
        if (Playerscript.instance.lastMap == "Crypt")
        {
            GameObject.FindWithTag("Player").transform.position = destinationPoint.transform.position;
        }
    }

    IEnumerator waitTime()
    {
        FadeBlack script = image.GetComponent<FadeBlack>();
        script.FadeOut(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
