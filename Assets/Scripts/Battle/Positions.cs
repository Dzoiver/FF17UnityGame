using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Positions
{
    public class Spot
    {
        Vector3 vector;
        bool isEmpty;

        public Vector3 Vector
        {
            get { return vector; }
            set { vector = value; }
        }

        // public bool IsEmpty
        // {
        //     set {return isEmpty;}
        //     get {isEmpty = value;}
        // }
        public bool IsEmpty
        {
            get { return isEmpty; }
            set { isEmpty = value; }
        }

        public bool isEnemy;

        public bool IsEnemy
        {
            get { return isEnemy; }
            set { isEnemy = value; }
        }

        public Spot(Vector3 vector, bool isEmpty, bool isEnemy)
        {
            this.vector = vector;
            this.isEmpty = isEmpty;
            this.isEnemy = isEnemy;
        }
    }

    public class Pos
    {
        static float enemyX = -7;
        static float enemyY = -1; 
        static float allyX = 7;
        static float allyY = enemyY;
        static float indent = 2; // Indent between characters position

        public static List<Spot> positionsList = new List<Spot>();
        
        // All coordinates for each spot
        static Vector3 pos1 = new Vector3(enemyX, enemyY + indent * 2, 0);
        static Vector3 pos2 = new Vector3(enemyX, enemyY + indent, 0);
        static Vector3 pos3 = new Vector3(enemyX, enemyY, 0);
        static Vector3 pos4 = new Vector3(allyX, allyY, 0);
        static Vector3 pos5 = new Vector3(allyX, allyY + indent, 0);
        static Vector3 pos6 = new Vector3(allyX, allyY + indent * 2, 0);

        static public void createAllpos()
        {
            // { Vector = pos1, IsEmpty = true, IsEnemy = true}
            positionsList.Add(new Spot(pos1, true, true));
            positionsList.Add(new Spot(pos2, true, true));
            positionsList.Add(new Spot(pos3, true, true));

            positionsList.Add(new Spot(pos4, true, false));
            positionsList.Add(new Spot(pos5, true, false));
            positionsList.Add(new Spot(pos6, true, false));
        }

        static public Vector3 getFreeVectEnemy()
        {
            for (int i = 0; i < positionsList.Count; i++)
            {
                if (positionsList[i].IsEnemy && positionsList[i].IsEmpty)
                {
                    Vector3 vect = positionsList[i].Vector;
                    positionsList[i].IsEmpty = false;
                    return vect;
                }
            }
            return new Vector3(0, 0, 0);
        }

        static public Vector3 getFreeVectAlly()
        {
            for (int i = 0; i < positionsList.Count; i++)
            {
                if (!positionsList[i].IsEnemy && positionsList[i].IsEmpty)
                {
                    Vector3 vect = positionsList[i].Vector;
                    return vect;
                }
            }
            return new Vector3(0, 0, 0);
        }

        // public static Vector3 getFreeEnemyPos()
        // {
        //     for (int i = 0; i < enemyArray.Length; i++)
        //     {
        //         if (enemyArray[i].isEmpty)
        //         {
        //         enemyArray[i].isEmpty = false;
        //         return enemyArray[i].vector;
        //         }
        //     }
        //     Vector3 vect = new Vector3(0, 0, 0);
        //     return vect;
        // }

        // public static Vector3 getFreeAllyPos()
        // {
        //     for (int i = 0; i < allyArray.Length; i++)
        //     {
        //         if (allyArray[i].isEmpty)
        //         {
        //         allyArray[i].isEmpty = false;
        //         return allyArray[i].vector;
        //         }
        //     }
        //     Vector3 vect = new Vector3(0, 0, 0);
        //     return vect;
        // }


        // public static Vector3 getFirstEnemyVector()
        // {
        //     foreach (EnemyPositions pos in enemyArray)
        //     {
        //         if (!pos.isEmpty)
        //         return pos.vector;
        //     }
        //     Vector3 vect = new Vector3(0, 0, 0);
        //     return vect;
        // }

        // public static int getFirstEnemyID()
        // {

        // }

        // public static Vector3 getFirstAllyVector()
        // {
        //     foreach (AllyPositions pos in allyArray)
        //     {
        //         if (!pos.isEmpty)
        //         return pos.vector;
        //     }
        //     Vector3 vect = new Vector3(0, 0, 0);
        //     return vect;
        // }

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
