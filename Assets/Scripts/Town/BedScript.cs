using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedScript : MonoBehaviour, IUsableObjects
{
    [SerializeField] FadeBlack fadeImageScript;
    public void Action()
    {
        InfoBox.instance.Ask("Take a rest?");
    }

    public void Sleep()
    {
        InfoBox.instance.Clear();
        StartCoroutine(FadeAndWait());
    }
    public void Cancel()
    {
        InfoBox.instance.Clear();
        Playerscript.instance.allowControl = true;
    }

    IEnumerator FadeAndWait()
    {
        fadeImageScript.FadeIn(2f);
        yield return new WaitForSeconds(2f);
        fadeImageScript.FadeOut(2f);
        yield return new WaitForSeconds(2f);
        Playerscript.instance.allowControl = true;
    }
}
