using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class WMDir : MonoBehaviour
{
    [SerializeField] GameObject cryptPos;
    [SerializeField] GameObject townPos;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        if (Finfor.instance == null)
        {
            Playerscript.instance.transform.position = townPos.transform.position;
            return;
        }
        Playerscript.instance.allowControl = false;

        Sequence seq = DOTween.Sequence();

        image.SetActive(true);
        image.GetComponent<Image>().DOFade(0, 1f).onComplete = () =>
        {
            Playerscript.instance.allowControl = true;
        };

        if (Finfor.instance.lastField == "Crypt")
        {
            CharactersScript.instance.PlaceCharacter(cryptPos.transform);
        }
        if (Finfor.instance.lastField == "Town")
        {
            CharactersScript.instance.PlaceCharacter(townPos.transform);
        }
        Finfor.instance.lastField = "WM";
        CameraScript.instance.FindPlayer();
        
    }
}
