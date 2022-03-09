using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;

namespace CharactersInBattle
{
    static public class Characters
    {
        static public int enemies = 0;
        static public int allies = 0;

        static GameObject[] alliesArray;
        static GameObject[] enemiesArray;

        

        static public void AddAlly(GameObject ally)
        {
            if (enemies > 3)
            return;
            
            alliesArray = new GameObject[] {ally};
            allies++;
            ally.transform.position = Pos.getFreeAllyPos();
            // alliesArray = ally.transform.position = Pos.pos4;
        }

        static public void AddEnemy(GameObject enemy)
        {
            if (enemies > 3)
            return;

            enemiesArray = new GameObject[] {enemy};
            enemies++;
            enemy.transform.position = Pos.getFreeEnemyPos();
        }
    }
    
}
