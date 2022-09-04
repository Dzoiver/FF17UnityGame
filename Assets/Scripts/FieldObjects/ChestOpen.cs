using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour, IUsableObjects
{
    [SerializeField] Sprite openChestSprite;
    public bool opened = false;

    public Item item;
    void Start()
    {
        if (Finfor.instance.chestOpened)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = openChestSprite;
            opened = true;
        }
    }
    public void Action()
    {
        if (!opened)
        {
            Finfor.instance.chestOpened = true;
            opened = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = openChestSprite;
            InfoBox.instance.Display("You got " + item.name);
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            Inventory.instance.Add(item);
        }
    }
}
