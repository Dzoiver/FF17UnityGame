using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;

namespace CharactersInBattle
{
    public interface IBattle
    {
        float Attack(IBattle target);
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



        // static public void AddAlly(GameObject ally)
        // {
        //     if (allies > 3)
        //     return;
        //     objectAllyList.Add(ally);
        //     allies++;
        //     ally.transform.position = Pos.getFreeAllyPos();
        // }

        // static public void AddEnemy(GameObject enemy)
        // {
        //     if (enemies > 3)
        //     return;
        //     objectEnemyList.Add(enemy);
        //     enemies++;
        //     enemy.transform.position = Pos.getFreeEnemyPos();
        // }
    }
    
}
