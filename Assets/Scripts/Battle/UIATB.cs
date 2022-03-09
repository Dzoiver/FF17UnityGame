﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIATB : MonoBehaviour
{
    public static UIATB instance { get; private set; }
    
    public Image mask;
    float originalSize;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // originalSize = mask.rectTransform.rect.width;
        originalSize = 1.96f;
    }

    public void SetValue(float value)
    {	
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}