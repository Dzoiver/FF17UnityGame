using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnterHouse : MonoBehaviour
{
    public GameObject destinationPoint;
    public GameObject fadeImage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Playerscript.instance.allowControl = false;
        Image image = fadeImage.GetComponent<Image>();

        image.DOFade(1, 1f).onComplete = () =>
        {
            other.transform.position = destinationPoint.transform.position;
            image.DOFade(0, 1f).onComplete = () =>
            {
                Playerscript.instance.allowControl = true;
            };
        };
    }
}
