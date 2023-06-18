using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EndDemo : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        Playerscript.instance.allowControl = false;
        image.DOFade(1, 5);
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1).onComplete = () =>
        {
            text.DOFade(1, 1.5f);
        };
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
