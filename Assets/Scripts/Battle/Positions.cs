using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Positions
{
    public struct AllyPositions
    {
        public Vector3 vector;
        public bool isEmpty;
        public int id;

        public AllyPositions(Vector3 vector, bool isEmpty, int id)
        {
            this.vector = vector;
            this.isEmpty = isEmpty;
            this.id = id;
        }
    }

    public struct EnemyPositions
    {
        public Vector3 vector;
        public bool isEmpty;
        public int id;

        public EnemyPositions(Vector3 vector, bool isEmpty, int id)
        {
            this.vector = vector;
            this.isEmpty = isEmpty;
            this.id = id;
        }
    }

    static public class Pos
    {
        static float enemyX = -7;
        static float enemyY = -1;
        static float indent = 2;

        static float allyX = 7;
        static float allyY = enemyY;

        public static AllyPositions[] allyArray = new AllyPositions[] {};
        public static EnemyPositions[] enemyArray = new EnemyPositions[] {};
        
        public static Vector3 pos1 = new Vector3(enemyX, enemyY + indent * 2, 0);
        public static Vector3 pos2 = new Vector3(enemyX, enemyY + indent, 0);
        public static Vector3 pos3 = new Vector3(enemyX, enemyY, 0);
        public static Vector3 pos4 = new Vector3(allyX, allyY, 0);
        public static Vector3 pos5 = new Vector3(allyX, allyY + indent, 0);
        public static Vector3 pos6 = new Vector3(allyX, allyY + indent * 2, 0);

        static public void createAllpos()
        {
            EnemyPositions ps1 = new EnemyPositions(pos1, true, 0);
            EnemyPositions ps2 = new EnemyPositions(pos2, true, 1);
            EnemyPositions ps3 = new EnemyPositions(pos3, true, 2);

            enemyArray = new EnemyPositions[] {ps1, ps2, ps3};

            AllyPositions ps4 = new AllyPositions(pos4, true, 5);
            AllyPositions ps5 = new AllyPositions(pos5, true, 4);
            AllyPositions ps6 = new AllyPositions(pos6, true, 3);

            allyArray = new AllyPositions[] {ps6, ps5, ps4};
        }

        public static Vector3 getFreeEnemyPos()
        {
            for (int i = 0; i < enemyArray.Length; i++)
            {
                if (enemyArray[i].isEmpty)
                {
                enemyArray[i].isEmpty = false;
                return enemyArray[i].vector;
                }
            }
            Debug.Log("default returned Enemy");
            Vector3 vect = new Vector3(0, 0, 0);
            return vect;
        }

        public static Vector3 getFreeAllyPos()
        {
            for (int i = 0; i < allyArray.Length; i++)
            {
                if (allyArray[i].isEmpty)
                {
                allyArray[i].isEmpty = false;
                return allyArray[i].vector;
                }
            }
            Vector3 vect = new Vector3(0, 0, 0);
            return vect;
        }


        public static Vector3 getFirstEnemyVector()
        {
            foreach (EnemyPositions pos in enemyArray)
            {
                if (!pos.isEmpty)
                return pos.vector;
            }
            Vector3 vect = new Vector3(0, 0, 0);
            return vect;
        }

        // public static int getFirstEnemyID()
        // {

        // }

        public static Vector3 getFirstAllyVector()
        {
            foreach (AllyPositions pos in allyArray)
            {
                if (!pos.isEmpty)
                return pos.vector;
            }
            Vector3 vect = new Vector3(0, 0, 0);
            return vect;
        }

        // public static Vector3 getPrevEnemy(int current)
        // {
        //     for (int i = current; i < enemiesArray.Length; i--)
        //     {
        //         if (!enemiesArray[i].isEmpty)
        //     }
        //     foreach (EnemyPositions pos in enemyArray)
        //     {
        //         if (!pos.isEmpty)
        //         return pos.vector;
        //     }
        //     Vector3 vect = new Vector3(0, 0, 0);
        //     return vect;
        // }
    }
}
