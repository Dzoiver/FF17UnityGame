using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Battle
{

}
public class Finfor : MonoBehaviour
{
    static public float hp = 250f;
    public static Vector3 vector = new Vector3(2, 0 , 0);
    public static bool isFujin = true;
    public static int currentPartyMembers = 0; 
    public static int currentBattleID; 


    // List<GameObject> charactersInParty = new List<GameObject>();

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}