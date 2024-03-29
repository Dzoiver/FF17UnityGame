﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public List<Item> items = new List<Item>();
    // private int space = 6;
    
    public void Add(Item item)
    {
        items.Add(item);

        if (onItemChangedCallback != null)
        onItemChangedCallback.Invoke();
    }
    

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        onItemChangedCallback.Invoke();
    }
}
