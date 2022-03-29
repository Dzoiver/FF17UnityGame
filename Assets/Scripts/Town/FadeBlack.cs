using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    public float fadeTime = 1f;
    float currentTime = 0.0f;
    public bool fade = false;
    Image imageComponent;
    public bool reverseFade = false;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            currentTime += Time.deltaTime;
            if (currentTime < fadeTime)
            {
                Color tempColor = imageComponent.color;
                tempColor.a += Time.deltaTime / fadeTime;
                imageComponent.color = tempColor;
            }
            else
            {
                fade = false;
                currentTime = 0f;
            }
        }

        if (reverseFade)
        {
            currentTime += Time.deltaTime;
            if (currentTime < fadeTime)
            {
                Color tempColor = imageComponent.color;
                tempColor.a -= Time.deltaTime / fadeTime; // 1 => 0
                imageComponent.color = tempColor;
            }
            else
            {
                reverseFade = false;
                currentTime = 0f;
            }
        }
        // else
        // {
        //     Color tempColor = imageComponent.color;
        //     tempColor.r = toBlack - currentTime;
        //     tempColor.g = toBlack - currentTime;
        //     tempColor.b = toBlack - currentTime;
        //     imageComponent.color = tempColor;
        // }
    }
}
