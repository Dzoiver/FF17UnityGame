using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    public GameObject destinationPoint;
    public GameObject fadeImage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Teleporting(other));
    }
    IEnumerator Teleporting(Collider2D other)
    {
        FadeBlack script = fadeImage.GetComponent<FadeBlack>();
        script.fade = true;
        Playerscript.allowControl = false;
        yield return new WaitForSeconds(script.fadeTime);
        other.transform.position = destinationPoint.transform.position;
        script.reverseFade = true;
        yield return new WaitForSeconds(script.fadeTime);
        Playerscript.allowControl = true;
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
