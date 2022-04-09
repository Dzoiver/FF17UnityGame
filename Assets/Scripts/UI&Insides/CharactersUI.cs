using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersUI : MonoBehaviour
{
    public Transform charParent;
    CharactersScript characters;

    CharacterSlot[] slots;

    void Start()
    {
        characters = CharactersScript.instance;
        characters.onCharactersChangedCallback += UpdateUI;
        Debug.Log(characters.onCharactersChangedCallback);

        slots = charParent.GetComponentsInChildren<CharacterSlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            
            if (i < characters.allyCharacters.Count)
            {
                slots[i].AddCharacter(characters.allyCharacters[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
