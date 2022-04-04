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
        dirScript.menuAppeared = false;

        target1.SetActive(false);
    }

    public GameObject damageTextPrefab;
    public GameObject DeathSFX;
    public GameObject HitSFX;
    // Update is called once per frame
    void Update()
    {
        if (!target1.activeSelf)
        return;

        if (Input.GetKeyDown("w"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            goToPrevEnemy();
        }

        if (Input.GetKeyDown("s"))
        {
            gameObject.GetComponent<AudioSource>().Play();
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
            gameObject.GetComponent<AudioSource>().Play();
            HitSFX.GetComponent<AudioSource>().Play();
            IBattle attackerScript = Finfor.allyListObject[atbID].instanceObj.GetComponent<IBattle>();
            IBattle targetScript = BattleDirector.enemyObjectList[currentPos].instanceObj.GetComponent<IBattle>();
            float dmg = attackerScript.Attack(targetScript);

            GameObject textObject = Instantiate(damageTextPrefab, transform, false);
            textObject.transform.position = BattleDirector.enemyObjectList[currentPos].instanceObj.transform.position;
            
            Text text = textObject.GetComponent<Text>();
            text.text = "-" + dmg;
            textObject.SetActive(true);
            
            if (targetScript.Hp <= 0)
            {
            DeathSFX.GetComponent<AudioSource>().Play(); // Enemy Death sound
            BattleDirector.enemyObjectList[currentPos].Alive = false;
            Pos.positionsList[currentPos].IsEmpty = true;
            }
            DeActivate();
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
        for (int i = 0; i < BattleDirector.enemyObjectList.Count; i++)
        {
            if (BattleDirector.enemyObjectList[i].IsEnemy && BattleDirector.enemyObjectList[i].Alive)
            {
                currentPos = i;
                target1.transform.position = BattleDirector.enemyObjectList[i].instanceObj.transform.position;
            }
        }
    }

    void goToPrevEnemy() // w
    {
        for (int i = currentPos - 1; i >= 0; i--) // Going from current to beginning
        {
            if (!Pos.positionsList[i].IsEmpty && Pos.positionsList[i].IsEnemy && BattleDirector.enemyObjectList[i].Alive)
            {
            currentPos = i;
            target1.transform.position = BattleDirector.enemyObjectList[i].instanceObj.transform.position;
            return;
            }
        }

        for (int i = BattleDirector.enemyObjectList.Count - 1; i >= 0; i--) // Going from last to beginning
        {
            if (!Pos.positionsList[i].IsEmpty && Pos.positionsList[i].IsEnemy && BattleDirector.enemyObjectList[i].Alive)
            {
            currentPos = i;
            target1.transform.position = BattleDirector.enemyObjectList[i].instanceObj.transform.position;
            return;
            }
        }
    }

    void goToNextEnemy() // s
    {
        for (int i = currentPos + 1; i < BattleDirector.enemyObjectList.Count; i++) // Going from current to last
        {
            if (!Pos.positionsList[i].IsEmpty && Pos.positionsList[i].IsEnemy && BattleDirector.enemyObjectList[i].Alive)
            {
            currentPos = i;
            target1.transform.position = BattleDirector.enemyObjectList[i].instanceObj.transform.position;
            return;
            }
        }

        for (int i = 0; i < BattleDirector.enemyObjectList.Count; i++) // Going from first to last
        {
            if (!Pos.positionsList[i].IsEmpty && Pos.positionsList[i].IsEnemy && BattleDirector.enemyObjectList[i].Alive)
            {
            currentPos = i;
            target1.transform.position = BattleDirector.enemyObjectList[i].instanceObj.transform.position;
            return;
            }
        }
    }
}
