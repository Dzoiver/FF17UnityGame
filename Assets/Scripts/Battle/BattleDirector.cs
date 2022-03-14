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
            if (value < maxATB)
            {
            amount = value; 
            isReady = false;
            }
            else if (value >= maxATB)
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
    float hp;
    float damage;
    bool isEnemy;
    GameObject object1;
    ATB atb;
    // Position pos;
}

// class Fujin : Character
// {

// }

public class BattleDirector : MonoBehaviour
{
    List<ATB> atbList = new List<ATB>();

    float maxATB = 30f;
    float atbSpeed = 10f;
    float atbTime = 0f;

    bool menuAppeared = false;

    bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        Pos.createAllpos();
        placeCharacters();
        fillATBlist();
        randomInitialATB();
        ChangeATB();
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        return;

        if (Characters.enemies == 0)
        EndBattle();

        fillATBs(atbSpeed * Time.deltaTime);
    }

    void fillATBlist()
    {
        for (int i = 0; i < Characters.enemies; i++)
        {
            atbList.Add(new ATB(){ Amount = 0f, IsEnemy=true});
        }
        for (int i = Characters.enemies; i < Characters.allies + Characters.enemies; i++)
        {
            atbList.Add(new ATB(){ Amount = 0f, IsEnemy=false});
        }
    }

    public GameObject victory; 
    public GameObject music; 

    void EndBattle()
    {
        Finfor.enemyList.Clear();
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
    SceneManager.LoadScene("Town");
    }

    public void ChangeATB()
    {
        // float currentHealth = Mathf.Clamp(allyATB_1 + value, 0, maxATB);
        UIATB.instance.SetValue(atbList[3].Amount / (float)maxATB);
    }

    void fillATBs(float rate)
    {
        for (int i = 0; i < atbList.Count; i++)
        {
            atbList[i].Amount += rate;
            if (atbList[i].IsReady && !atbList[i].IsEnemy)
            {
                battleMenuAppear(i);
            }
            else if (atbList[i].IsReady && atbList[i].IsEnemy)
            {
                // Enemy attack
                // enemy.Turn();
                // IBattle targetScript = playerObject.GetComponent<IBattle>();
                // targetScript
            }
        }

        ChangeATB();
    }

    void randomInitialATB()
    {
        for (int i = 0; i < Characters.allies + Characters.enemies; i++)
        {
            atbList[i].Amount = 25f;
            // atbList[i].Amount = Random.Range(0f, maxATB);;
        }
    }

    public GameObject PlayerFighting;
    public GameObject FujinFighting;
    
    void placeCharacters() // Better to rework this part so characters automatically being counted
    {
        GameObject playerObject = Instantiate(PlayerFighting);
        // GameObject playerObject1 = Instantiate(PlayerFighting);
        // GameObject playerObject2 = Instantiate(PlayerFighting);
        for (int i = 0; i < Finfor.enemyList.Count; i++)
        {
            Debug.Log("list: " + Finfor.enemyList[i]);
            Characters.AddEnemy(Instantiate(Finfor.enemyList[i]));
        }
        
        // GameObject fujinObject = Instantiate(FujinFighting);
        // GameObject fujinObject1 = Instantiate(FujinFighting);
        // GameObject fujinObject2 = Instantiate(FujinFighting);

        Characters.AddAlly(playerObject);
        // Characters.AddAlly(playerObject1);
        // Characters.AddAlly(playerObject2);

        // Characters.AddEnemy(fujinObject);
        // Characters.AddEnemy(fujinObject1);
        // Characters.AddEnemy(fujinObject2);
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
        BattleMenu script = battleMenu.GetComponent<BattleMenu>();
        script.Activate(index);
    }

    public void resetATB(int atbID)
    {
        atbList[atbID].Amount = 0f;
    }
}