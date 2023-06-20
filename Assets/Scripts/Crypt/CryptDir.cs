using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CryptDir : MonoBehaviour
{
    [SerializeField] GameObject image;
    void Start()
    {
        if (Finfor.instance != null)
        {
            Finfor.instance.lastField = "Crypt";
            Playerscript.instance.gameObject.transform.position = Finfor.instance.startVector;
        }
        CameraScript.instance.FindPlayer();
        Playerscript.instance.allowControl = false;

        image.SetActive(true);
        image.GetComponent<Image>().DOFade(0, 1f).onComplete = () =>
        {
            Playerscript.instance.allowControl = true;
        };
    }
}
