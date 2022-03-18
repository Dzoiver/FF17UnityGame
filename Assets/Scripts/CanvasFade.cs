using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFade : MonoBehaviour
{
    float currentTime = 0.0f;
    float destroyTime = 1f;
    float toBlack = 2f;
    Image imageComponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        imageComponent = GetComponent<Image>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime < destroyTime)
        {
            Color tempColor = imageComponent.color;
            tempColor.a = currentTime/destroyTime;
            imageComponent.color = tempColor;
        }
        else
        {
            Color tempColor = imageComponent.color;
            tempColor.r = toBlack - currentTime;
            tempColor.g = toBlack - currentTime;
            tempColor.b = toBlack - currentTime;
            imageComponent.color = tempColor;
        }
        
    }
}
