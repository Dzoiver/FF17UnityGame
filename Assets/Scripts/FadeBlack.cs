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
    bool fadeColor = false;
    float red = 0;
    float green = 0;
    float blue = 0;
    float redTo = 0;
    float greenTo = 0;
    float blueTo = 0;
    float redDiff = 0;
    float greenDiff = 0;
    float blueDiff = 0;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
    }
    public void setImageAlpha(float value)
    {
        Color tempColor = imageComponent.color;
        tempColor.a = value;
        imageComponent.color = tempColor;
    }

    public void FadeOut(float time)
    {
        Color tempColor = imageComponent.color;
        tempColor.a = 1;
        imageComponent.color = tempColor;

        fadeTime = time;
        reverseFade = true;
    }

    public void FadeIn(float time, Color color)
    {
        Color tempColor = imageComponent.color;
        tempColor = color;
        tempColor.a = 0;
        imageComponent.color = tempColor;

        fadeTime = time;
        fade = true;
    }

    public void FadeIn(float time)
    {
        Color tempColor = imageComponent.color;
        tempColor.a = 0;
        imageComponent.color = tempColor;

        fadeTime = time;
        fade = true;
    }

    public void FadeColor(float time, Color colorFrom, Color colorIn)
    {
        imageComponent.color = colorFrom;
        fadeTime = time;
        fadeColor = true;
        red = colorFrom.r;
        green = colorFrom.g;
        blue = colorFrom.b;

        redTo = colorIn.r;
        greenTo = colorIn.g;
        colorIn.b = blueTo;

        redDiff = redTo - red;
        greenDiff = greenTo - green;
        blueDiff = blueTo - blue;
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

        if (fadeColor)
        {
            currentTime += Time.deltaTime;
            if (currentTime < fadeTime)
            {
                Color tempColor = imageComponent.color;
                tempColor.r += (redDiff * Time.deltaTime) / fadeTime;
                tempColor.g += (greenDiff * Time.deltaTime) / fadeTime;
                tempColor.b += (blueDiff * Time.deltaTime) / fadeTime;
                imageComponent.color = tempColor;
            }
            else
            {
                fadeColor = false;
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
