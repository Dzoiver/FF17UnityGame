using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    Text charName;
    Image charImage;
    Text charHP;


    void Start()
    {
        charName = gameObject.transform.Find("Name").GetComponent<Text>();

    }

    public void AddCharacter(CharacterScriptable character)
    {
        // IBattle charScript = character.GetComponent<IBattle>();
        // charName.text = charScript.name;
        charName.text = character.name;
        Debug.Log(charName.text);
    }

    public void ClearSlot()
    {
        
    }
}
