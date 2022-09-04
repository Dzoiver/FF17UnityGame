using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    Text charName;
    void Start()
    {
        charName = gameObject.transform.Find("Name").GetComponent<Text>();
    }

    public void AddCharacter(CharacterScriptable character)
    {
        charName.text = character.name;
        Debug.Log(charName.text);
    }

    public void ClearSlot()
    {
        
    }
}
