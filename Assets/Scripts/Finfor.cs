using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Finfor : MonoBehaviour
{
    public static Vector3 startVector = new Vector3(1f, 5f, 0f);
    public static bool fujinStarted = false;
    public static int currentPartyMembers = 0; 
    public static int currentBattleID; 
    public static List<GameObject> enemyListPrefab = new List<GameObject>();
    public static List<GameObject> allyListPrefab = new List<GameObject>();
    public static List<CharBat> allyListObject = new List<CharBat>();
    public static bool SvortStarted = false;
    public static int progress = 0;
    public static bool svortInWMSeen = false;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (progress > 0)
        {
        Destroy(gameObject);
        return;
        }
        allyListPrefab.Add(player);
        for (int i = 0; i < allyListPrefab.Count; i++)
        {
            CharBat charact = new CharBat();
            charact.atb = new ATB(){ Amount = 0f};
            charact.IsEnemy = false;
            charact.prefabObj = allyListPrefab[i];
            charact.instanceObj = Instantiate(charact.prefabObj);
            allyListObject.Add(charact);
        }
        progress = 1;
    }
    public GameObject player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}