using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;
using CharactersInBattle;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public GameObject target1;
    public GameObject battleMenu;
    public GameObject director;

    int currentPos = 0;
    int atbID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Activate(int index) // Shows the cursor on targets
    {
        atbID = index;
        goToFirstEnemy();
        target1.SetActive(true);
    }

    public void DeActivate() // Hides the cursor
    {
        BattleMenu script = battleMenu.GetComponent<BattleMenu>(); 
        script.DeActivate();
        BattleDirector dirScript = director.GetComponent<BattleDirector>(); 
        dirScript.resetATB(atbID);

        target1.SetActive(false);
    }

    public GameObject damageTextPrefab;
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
            //foreach (GameObject g in Characters.enemiesArray)
            
            // Characters.enemies = 0;
            // GameObject target = Characters.objectEnemyList[currentPos];
            // GameObject attacker = Characters.objectAllyList[0];

            IBattle attackerScript = BattleDirector.characterList[atbID].instanceObj.GetComponent<IBattle>();
            IBattle targetScript = BattleDirector.characterList[currentPos].instanceObj.GetComponent<IBattle>();
            float dmg = attackerScript.Attack(targetScript);
            // GameObject fujinObject = Instantiate(FujinFighting); 
            // GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            // Projectile projectile = projectileObject.GetComponent<Projectile>();
            // projectile.Launch(lookDirection, 300);
            // animator.SetTrigger("Launch");
            GameObject textObject = Instantiate(damageTextPrefab, transform, false);
            textObject.transform.position = BattleDirector.characterList[currentPos].instanceObj.transform.position;
            
            Text text = textObject.GetComponent<Text>();
            text.text = "-" + dmg;
            textObject.SetActive(true);
            // rez.Attack(fujin);
            
            if (targetScript.Hp <= 0)
            {
            BattleDirector.characterList[currentPos].Alive = false;
            Pos.positionsList[currentPos].IsEmpty = true;
            }
            DeActivate();
            
            //Characters.alliesArray[0].Attack(target);
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
        for (int i = 0; i < BattleDirector.characterList.Count; i++)
        {
            if (BattleDirector.characterList[i].IsEnemy && BattleDirector.characterList[i].Alive)
            {
                currentPos = i;
                target1.transform.position = BattleDirector.characterList[i].instanceObj.transform.position;
            }
        }
    }

    void goToPrevEnemy() // w
    {
        for (int i = currentPos - 1; i >= 0; i--) // Going from current to beginning
        {
            if (!Pos.positionsList[i].IsEmpty && Pos.positionsList[i].IsEnemy && BattleDirector.characterList[i].Alive)
            {
            currentPos = i;
            target1.transform.position = BattleDirector.characterList[i].instanceObj.transform.position;
            return;
            }
        }

        for (int i = BattleDirector.characterList.Count - 1; i >= 0; i--) // Going from last to beginning
        {
            if (!Pos.positionsList[i].IsEmpty && Pos.positionsList[i].IsEnemy && BattleDirector.characterList[i].Alive)
            {
            currentPos = i;
            target1.transform.position = BattleDirector.characterList[i].instanceObj.transform.position;
            return;
            }
        }
    }

    void goToNextEnemy() // s
    {
        for (int i = currentPos + 1; i < BattleDirector.characterList.Count; i++) // Going from current to last
        {
            if (!Pos.positionsList[i].IsEmpty && Pos.positionsList[i].IsEnemy && BattleDirector.characterList[i].Alive)
            {
            currentPos = i;
            target1.transform.position = BattleDirector.characterList[i].instanceObj.transform.position;
            return;
            }
        }

        for (int i = 0; i < BattleDirector.characterList.Count; i++) // Going from first to last
        {
            if (!Pos.positionsList[i].IsEmpty && Pos.positionsList[i].IsEnemy && BattleDirector.characterList[i].Alive)
            {
            currentPos = i;
            target1.transform.position = BattleDirector.characterList[i].instanceObj.transform.position;
            return;
            }
        }
    }
}
