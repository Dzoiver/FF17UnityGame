using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Char", menuName = "Character")]
public class CharacterScriptable : ScriptableObject
{
    new public string name = "New Char";
    public Sprite icon = null;
    public int maxHealth = 0;
    public int currenHealth = 0;
    public int damage = 0;
    public GameObject worldPrefab;
    public GameObject prefab;
    public float MaxAtb = 12000f;
    public float atb = 0f;
    public float atbSpeed = 1f;
}
