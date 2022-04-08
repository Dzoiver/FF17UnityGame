using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI slotText;
    Transform button;
    
    Item item;

    void Start()
    {
        icon = gameObject.transform.FindChild("Image").gameObject.GetComponent<Image>();
        // button = gameObject.transform.FindChild("Button");
        slotText = gameObject.transform.FindChild("Button").gameObject.transform.FindChild("Text").gameObject.GetComponent<TextMeshProUGUI>();
        // slotText = button.FindChild("Text").gameObject.GetComponent<Text>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        slotText.text = item.name;
        Debug.Log(slotText);
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        
        icon.sprite = null;
        icon.enabled = false;
    }
}
