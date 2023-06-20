using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersScript : MonoBehaviour
{
    #region Singleton
    public static CharactersScript instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of CharactersScript found!");
            return;
        }
        DontDestroyOnLoad(this);
        instance = this;
    }

    #endregion
    
    public delegate void onCharactersChanged();
    public onCharactersChanged onCharactersChangedCallback;
    public List<CharacterScriptable> allyCharacters = new List<CharacterScriptable>();
    int space = 3;
    int membersNumber = 0;

    public int MembersNumber
    {
        get { return membersNumber; }
    }

    public void Add(CharacterScriptable ally)
    {
        if (membersNumber < space)
        {
            membersNumber++;
            allyCharacters.Add(ally);
            if (onCharactersChangedCallback != null)
                onCharactersChangedCallback.Invoke();
        }
    }

    public void PlaceCharacter(Transform trans)
    {
        Playerscript.instance.transform.position = trans.position;
    }
}
