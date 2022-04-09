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
        instance = this;
    }

    #endregion
    
    public delegate void onCharactersChanged();
    public onCharactersChanged onCharactersChangedCallback;
    public List<CharacterScriptable> allyCharacters = new List<CharacterScriptable>();
    int space = 3;
    public bool allowMovement;

    public void Add(CharacterScriptable ally)
    {
        allyCharacters.Add(ally);
        if (onCharactersChangedCallback != null)
        onCharactersChangedCallback.Invoke();
    }
    public void Remove()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
