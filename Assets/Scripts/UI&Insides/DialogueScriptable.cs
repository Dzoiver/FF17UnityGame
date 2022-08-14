using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueScriptable : ScriptableObject
{
    public List<string> messages = new List<string>();
}
