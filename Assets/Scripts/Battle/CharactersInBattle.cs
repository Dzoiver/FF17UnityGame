using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;


public interface IBattle
    {
        float Attack(IBattle target);

        bool StepUp
        {
            get;
            set;
        }

        bool Backup
        {
            get;
            set;
        }
        int Index
        {
            get;
            set;
        }
        float Hp {
        get;
        set;
    }

        float Damage {
        get;
    }
    }


    static public class Characters
    {
        static public int enemies = 0;
        static public int allies = 0;

        static public List<GameObject> objectEnemyList = new List<GameObject>();
        static public List<GameObject> objectAllyList = new List<GameObject>();
    }

