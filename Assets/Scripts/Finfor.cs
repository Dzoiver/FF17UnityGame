﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Finfor : MonoBehaviour
{
    // static public float hp = 250f;
    public static Vector3 vector = new Vector3(2, 0 , 0);
    public static bool fujinStarted = false;
    public static int currentPartyMembers = 0; 
    public static int currentBattleID; 
    public static List<GameObject> enemyList = new List<GameObject>();
    public static List<GameObject> allyList = new List<GameObject>();
    public static bool SvortStarted = false;


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