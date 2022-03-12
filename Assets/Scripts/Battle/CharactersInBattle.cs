using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;

namespace CharactersInBattle
{
    public interface IBattle
    {
        float getHP();
        float getDamage();
        float Attack(IBattle target);
        
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

        public static GameObject[] alliesArray = new GameObject[3];
        public static GameObject[] enemiesArray = new GameObject[3];

        

        static public void AddAlly(GameObject ally)
        {
            if (allies > 3)
            return;
            Debug.Log(alliesArray);
            alliesArray[allies] = ally;
            allies++;
            ally.transform.position = Pos.getFreeAllyPos();
            // alliesArray = ally.transform.position = Pos.pos4;
        }

        static public void AddEnemy(GameObject enemy)
        {
            if (enemies > 3)
            return;

            enemiesArray[enemies] = enemy;
            enemies++;
            enemy.transform.position = Pos.getFreeEnemyPos();
        }
    }
    
}
