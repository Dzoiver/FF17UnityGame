using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finfor : MonoBehaviour
{
    public Vector3 startVector = new Vector3(1f, 5f, 0f);
    public static int currentPartyMembers = 0; 
    public static int currentBattleID;
    public static List<CharacterScriptable> enemyListScriptable = new List<CharacterScriptable>();
    public static List<CharacterScriptable> allyListScriptable = new List<CharacterScriptable>();
    public static List<CharBat> allyListObject = new List<CharBat>();
    public int progress = 0; // Story progress
    public bool svortInWMSeen = false;
    public string lastField = "";
    public bool cryptConversationFinished = false;
    public bool chestOpened = false;

    public static Finfor instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Finfor found!");
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this);
        if (progress > 0)
        {
            Destroy(gameObject);
            return;
        }
        allyListScriptable.Add(player);
        for (int i = 0; i < allyListScriptable.Count; i++)
        {
            CharBat charact = new CharBat();
            charact.atb = new ATB(){ Amount = 0f};
            charact.IsEnemy = false;
            charact.prefabObj = allyListScriptable[i].prefab;
            charact.hp = allyListScriptable[i].currenHealth;
            allyListObject.Add(charact);
        }
        progress = 1;
    }
    public CharacterScriptable player;
}