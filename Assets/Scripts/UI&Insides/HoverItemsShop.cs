using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverItemsShop : MonoBehaviour
{
    [SerializeField] Text descriptionText;
    [SerializeField] Item item;
    // Start is called before the first frame update
    void Start()
    {
        Text buttonText = GetComponentInChildren<Text>();
        buttonText.text = item.name;
    }
    delegate void IPointerEnterHandler(string message);
    event IPointerEnterHandler Enter;

    delegate void IPointerExitHandler(string message);
    event IPointerExitHandler Exit;

    public void ChangeDescription()
    {
        descriptionText.text = item.description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
