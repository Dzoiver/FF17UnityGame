using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;
using CharactersInBattle;

public class Target : MonoBehaviour
{
    public GameObject target1;
    int currentPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Activate() // Shows the cursor on targets
    {
        goToFirstEnemy();
        target1.SetActive(true);
    }

    public void DeActivate() // Hides the cursor
    {
        target1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!target1.activeSelf)
        return;

        if (Input.GetKeyDown("w"))
        {
            goToPrevEnemy();
        }

        if (Input.GetKeyDown("s"))
        {
            goToNextEnemy();
        }

        if (Input.GetKeyDown("a"))
        {
            Left();
        }

        if (Input.GetKeyDown("d"))
        {
            Right();
        }

        if (Input.GetKeyDown("space"))
        {
            Characters.enemies = 0;
            // CurrentPlayer.Attack(Target);
        }




    }

    void Right()
    {
        
    }

    void Left()
    {
        
    }

    void goToFirstEnemy()
    {
        for (int i = Pos.enemyArray.Length - 1; i >= 0; i--)
        {
            if (!Pos.enemyArray[i].isEmpty)
            {
            currentPos = Pos.enemyArray[i].id;
            target1.transform.position = Pos.enemyArray[i].vector;
            }
        }
    }

    void goToPrevEnemy()
    {
        for (int i = currentPos - 1; i >= 0; i--) // Going from current to beginning
        {
            if (!Pos.enemyArray[i].isEmpty)
            {
            currentPos = Pos.enemyArray[i].id;
            target1.transform.position = Pos.enemyArray[i].vector;
            return;
            }
        }

        for (int i = Pos.enemyArray.Length - 1; i >= 0; i--) // Going from last to beginning
        {
            if (!Pos.enemyArray[i].isEmpty)
            {
            currentPos = Pos.enemyArray[i].id;
            target1.transform.position = Pos.enemyArray[i].vector;
            return;
            }
        }
    }

    void goToNextEnemy()
    {
        for (int i = currentPos + 1; i < Pos.enemyArray.Length; i++) // Going from current to last
        {
            if (!Pos.enemyArray[i].isEmpty)
            {
            currentPos = Pos.enemyArray[i].id;
            target1.transform.position = Pos.enemyArray[i].vector;
            return;
            }
        }

        for (int i = 0; i < Pos.enemyArray.Length; i++) // Going from first to last
        {
            if (!Pos.enemyArray[i].isEmpty)
            {
            currentPos = Pos.enemyArray[i].id;
            target1.transform.position = Pos.enemyArray[i].vector;
            return;
            }
        }
    }
}
