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
        script.FadeIn(1f);
        Playerscript.instance.allowControl = false;
        yield return new WaitForSeconds(script.fadeTime);
        other.transform.position = destinationPoint.transform.position;
        script.FadeOut(1f);
        yield return new WaitForSeconds(script.fadeTime);
        Playerscript.instance.allowControl = true;
    }
}
