using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Finfor : MonoBehaviour
{
    // static public float hp = 250f;
    public static Vector3 vector = new Vector3(2, 0 , 0);
    public static bool fujinStarted = false;
    public static int currentPartyMembers = 0; 
    public static int currentBattleID; 
    public static List<GameObject> enemyListPrefab = new List<GameObject>();
    public static List<GameObject> allyListPrefab = new List<GameObject>();
    public static List<CharBat> allyListObject = new List<CharBat>();
    public static bool SvortStarted = false;
    public static int progress = 0;


    // List<GameObject> charactersInParty = new List<GameObject>();

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
            Debug.Log("creating player objects");
            // atbList.Add(new ATB(){ Amount = 0f, IsEnemy=true});
            CharBat charact = new CharBat();
            charact.atb = new ATB(){ Amount = 0f};
            charact.IsEnemy = false;
            charact.prefabObj = allyListPrefab[i];
            charact.instanceObj = Instantiate(charact.prefabObj);
            // charact.atb = new ATB(){ Amount = 0f, IsEnemy=false};

            allyListObject.Add(charact);
        }
        progress = 1;
    }
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}