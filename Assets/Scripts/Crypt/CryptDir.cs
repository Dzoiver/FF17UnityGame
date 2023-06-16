using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptDir : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject image;
    [SerializeField] GameObject playerObject;
    void Start()
    {
        if (Finfor.instance != null)
        {
            Finfor.instance.lastField = "Crypt";
            playerPrefab.transform.position = Finfor.instance.startVector;
        }
        Playerscript.instance.allowControl = false;
        StartCoroutine(waitTime());
    }

    IEnumerator waitTime()
    {
        FadeBlack script = image.GetComponent<FadeBlack>();
        script.FadeOut(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
    }
}
