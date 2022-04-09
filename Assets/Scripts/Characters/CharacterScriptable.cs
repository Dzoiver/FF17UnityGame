using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ally", menuName = "Character/Ally")]
public class CharacterScriptable : ScriptableObject
{
    new public string name = "New Ally";
    public Sprite icon = null;
    public int maxHealth = 0;
    public int currenHealth = 0;
    public int damage = 0;
    public GameObject prefab;
}
