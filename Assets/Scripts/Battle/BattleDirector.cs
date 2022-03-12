using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Positions;
using CharactersInBattle;
using UnityEngine.SceneManagement;

class ATB
{
    float amount;
    bool isEnemy;
    bool isReady;
    float maxATB = 30f;

    public float Amount 
    {
        get { return amount; }
        set {
            if (amount < maxATB)
            {
            amount = value; 
            isReady = false;
            }
            else
            {
            amount = maxATB;
            isReady = true;
            }
        }
    }

    public bool IsEnemy 
    {
        get { return isEnemy; }
        set { isEnemy = value; }
    }

    public bool IsReady
    {
        get { return isReady; }
        set { isReady = value; }
    }
}

class Character
{
    bool isEnemy;
    float health;
    float damage;
    Vector3 position;
}

public class BattleDirector : MonoBehaviour
{
    List<ATB> atbList = new List<ATB>();
    // float allyATB_1 = 0f;
    // float enemyATB_1 = 0f;

    // float allyATB_2 = 0f;
    // float enemyATB_2 = 0f;

    // float allyATB_3 = 0f;
    // float enemyATB_3 = 0f;

    float maxATB = 30f;
    float atbRate = 0.03f;
    float atbTime = 0f;
    // bool isATBready1 = false;
    // bool isEnemyATBready1 = false;

    // bool isATBready2 = false;
    // bool isEnemyATBready2 = false;

    // bool isATBready3 = false;
    // bool isEnemyATBready3 = false;

    bool menuAppeared = false;

    bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        randomInitialATB();
        Pos.createAllpos();
        placeCharacters();
        Debug.Log("check");
        fillATBlist();
        ChangeATB();
    }

    // Update is called once per frame
    void Update()
    {
        if (Characters.enemies == 0 && !end)
        EndBattle();

        fillATBs(0.02f);
    }

    void fillATBlist()
    {
        Debug.Log("Characters.enemies " + Characters.enemies);
        for (int i = 0; i < Characters.enemies; i++)
        {
            atbList.Add(new ATB(){ Amount = 0f, IsEnemy=true});
            Debug.Log("new ATB at index " + i);
        }
        for (int i = Characters.enemies; i < Characters.allies + Characters.enemies; i++)
        {
            Debug.Log("new ATB at index " + i);
            atbList.Add(new ATB(){ Amount = 0f, IsEnemy=false});
        }
    }

    public GameObject victory; 
    public GameObject music; 

    void EndBattle()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
    end = true;
    AudioSource victory1 = victory.GetComponent<AudioSource>();
    AudioSource music1 = music.GetComponent<AudioSource>();
    music1.Stop();
    victory1.Play(0);
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene("SampleScene");
    }

    public void ChangeATB()
    {
        // float currentHealth = Mathf.Clamp(allyATB_1 + value, 0, maxATB);
        
        UIATB.instance.SetValue(atbList[0].Amount / (float)maxATB);
    }

    void fillATBs(float rate)
    {
        // foreach (float atb in atbList)
        // {
        //     if (atb < maxATB)
        //     atb += rate;
        // }
        Debug.Log(atbList.Count + " atbList.Count");
        for (int i = 0; i < atbList.Count; i++)
        {
            atbList[i].Amount += rate;
            if (atbList[i].IsReady)
            battleMenuAppear(i);
        }

        // if (allyATB_1 < maxATB)
        // allyATB_1 += rate;
        // else
        // isATBready1 = true;

        // if (enemyATB_1 < maxATB)
        // enemyATB_1 += rate;
        // else
        // isEnemyATBready1 = true;

        ChangeATB();
    }

    void randomInitialATB()
    {
        for (int i = 0; i < Characters.allies + Characters.enemies; i++)
        {
            atbList[i].Amount = 5f;
            // atbList[i].Amount = Random.Range(0f, maxATB);;
        }
        // allyATB_1 = Random.Range(0f, maxATB);
        // enemyATB_1 = Random.Range(0f, maxATB);
    }

    public GameObject PlayerFighting;
    public GameObject FujinFighting;
    
    void placeCharacters() // Better to rework this part so characters automatically being counted
    {
        GameObject playerObject = Instantiate(PlayerFighting);
        GameObject playerObject1 = Instantiate(PlayerFighting);
        GameObject playerObject2 = Instantiate(PlayerFighting);
        
        GameObject fujinObject = Instantiate(FujinFighting);
        GameObject fujinObject1 = Instantiate(FujinFighting);
        GameObject fujinObject2 = Instantiate(FujinFighting);

        Characters.AddAlly(playerObject);
        Characters.AddAlly(playerObject1);
        Characters.AddAlly(playerObject2);

        Characters.AddEnemy(fujinObject);
        Characters.AddEnemy(fujinObject1);
        Characters.AddEnemy(fujinObject2);
    }

    // void updateATBgraphics()
    // {
    //     float originalSize = allyATB_1_Graphics.rectTransform.rect.width;
    //     float value = allyATB_1 / maxATB;
    //     Vector3 vect = new Vector3(0, 0, 0);
    //     allyATB_1_Graphics.rectTransform.localScale = vect;
    // }

    public GameObject battleMenu;

    void battleMenuAppear(int index)
    {
        menuAppeared = true;
        int atbID = 0;
        BattleMenu script = battleMenu.GetComponent<BattleMenu>();
        script.Activate(atbID);
    }

    public void resetATB(int atbID)
    {

    }
}

/*
at the start of the battle initialize in static class:
Enemy class
Ally class




*/