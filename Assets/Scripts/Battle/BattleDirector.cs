using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Positions;
using CharactersInBattle;
using UnityEngine.SceneManagement;

public class ATB
{
    float amount;
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

    public bool IsReady
    {
        get { return isReady; }
        set { isReady = value; }
    }
}

public class CharBat
{

    bool alive = true;
    public bool Alive
    {
        get{ return alive; }
        set{ alive = value; }
    }

    bool isEnemy;
    public bool IsEnemy 
    {
        get { return isEnemy; }
        set { isEnemy = value; }
    }
    public GameObject prefabObj;
        public GameObject PrefabObj 
    {
        get { return prefabObj; }
        set { prefabObj = value; }
    }
    public GameObject instanceObj;
        public GameObject InstanceObj 
    {
        get { return instanceObj; }
        set { instanceObj = value; }
    }

    public ATB atb;

    public ATB Atb 
    {
        get { return atb; }
        set { atb = value; }
    }

    public GameObject textHpObject;
}

// class Fujin : Character
// {

// }

public class BattleDirector : MonoBehaviour
{
    static public List<CharBat> enemyObjectList = new List<CharBat>(); // List of all characters in a battle including enemies

    float maxATB = 30f; // Max value of ATB
    float atbSpeed = 10f; // Speed of the ATB bar
    public bool menuAppeared = false; // Prevents several menu from stacking on the screen
    bool end = false; // Set to true when all enemies slain
    CharBat charact;
    bool activeTurn = false;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public List<GameObject> Hptext = new List<GameObject>();
    public GameObject fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        FadeBlack script = fadeImage.GetComponent<FadeBlack>();
        script.FadeOut(1f);
        Hptext.Add(text3);
        Hptext.Add(text2);
        Hptext.Add(text1);

        Pos.createAllpos();
        placeCharacters();
        // fillATBlist();
        randomInitialATB();
        // Hpbar.GetComponent<Healthbar>().setHp();
        ChangeATB();
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        return;

        if (Characters.enemies == 0 || Characters.allies == 0)
        EndBattle();

        fillATBs(atbSpeed * Time.deltaTime);
    }

    public GameObject victory; 
    public GameObject music; 

    void EndBattle()
    {
        enemyObjectList.Clear();
        Finfor.enemyListPrefab.Clear();
        Characters.objectEnemyList.Clear();
        Characters.objectAllyList.Clear();
        if (Characters.enemies == 0)
        {
        StartCoroutine(VictoryEnd());
        }
        else if (Characters.allies == 0)
        {
        StartCoroutine(DefeatEnd());
        }
    }

    IEnumerator VictoryEnd()
    {
    end = true;
    AudioSource victory1 = victory.GetComponent<AudioSource>();
    AudioSource music1 = music.GetComponent<AudioSource>();
    music1.Stop();
    victory1.Play(0);
    yield return new WaitForSeconds(5);
    for (int i = 0; i < Finfor.allyListObject.Count; i++)
    {
        Finfor.allyListObject[i].instanceObj.SetActive(false);
    }
    SceneManager.LoadScene(Playerscript.lastMap);
    }

    public GameObject lose; 
    IEnumerator DefeatEnd()
    {
    end = true;
    AudioSource lose1 = lose.GetComponent<AudioSource>();
    AudioSource music1 = music.GetComponent<AudioSource>();
    music1.Stop();
    lose1.Play(0);
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene("StartScreen");
    }

    public void ChangeATB()
    {
        // float currentHealth = Mathf.Clamp(allyATB_1 + value, 0, maxATB);
        for (int i = 0; i < Finfor.allyListObject.Count; i++)
        {
            UIATB.instance.SetValue(Finfor.allyListObject[i].atb.Amount / (float)maxATB);
        }
    }
    public GameObject damageTextPrefab;
    public GameObject targetHandle;

    void fillATBs(float rate) // Fill ALL charcaters ATB
    {
        if (activeTurn)
        return;

        for (int i = 0; i < Finfor.allyListObject.Count; i++) // Allies first
        {
            Finfor.allyListObject[i].atb.Amount += rate;
            if (Finfor.allyListObject[i].atb.IsReady && !menuAppeared)
            {
                battleMenuAppear(i); // If ready, menu appears
            }
        }
        for (int i = 0; i < enemyObjectList.Count; i++)
        {
            enemyObjectList[i].atb.Amount += rate;
            if (enemyObjectList[i].atb.IsReady && enemyObjectList[i].Alive)
            {
                StartCoroutine(TurnAnimation(i));
            }
        }

        ChangeATB();
    }

    IEnumerator TurnAnimation(int i)
    {
        activeTurn = true; // Block other turns while current happens

        IBattle attackerScript = enemyObjectList[i].instanceObj.GetComponent<IBattle>();

        int randomAllyIndex = getRandomAllyIndex();
        IBattle targetScript = Finfor.allyListObject[randomAllyIndex].instanceObj.GetComponent<IBattle>();
        attackerScript.StepUp = true;
        yield return new WaitForSeconds(0.4f);
        float dmg = attackerScript.Attack(targetScript); // Actual attack to player

        GameObject textObject = Instantiate(damageTextPrefab, targetHandle.transform, false);
        textObject.transform.position = Finfor.allyListObject[randomAllyIndex].instanceObj.transform.position;
        Text hptext = Finfor.allyListObject[randomAllyIndex].textHpObject.GetComponent<Text>();
        hptext.text = (int.Parse(hptext.text) - dmg).ToString(); // Text update
        
        Text text = textObject.GetComponent<Text>();
        text.text = "-" + dmg;
        textObject.SetActive(true); // DMG number appear
        targetScript.Hp -= dmg;
        
        if (targetScript.Hp <= 0) // Check whether the player is dead after hit
        {
        Finfor.allyListObject[randomAllyIndex].Alive = false;
        Pos.positionsList[randomAllyIndex].IsEmpty = true;
        Characters.allies--;
        }
        yield return new WaitForSeconds(0.4f);
        attackerScript.Backup = true;
        BattleDirector.enemyObjectList[i].atb.IsReady = false;
        BattleDirector.enemyObjectList[i].atb.Amount = 0f;
        activeTurn = false;
    }

    int getRandomAllyIndex()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < Finfor.allyListObject.Count; i++)
        {
            if (Finfor.allyListObject[i].Alive && !Finfor.allyListObject[i].IsEnemy) 
            {
                list.Add(i);
            }
        } 
        return Random.Range(list[0], list[list.Count - 1]);
    }

    void randomInitialATB()
    {
        for (int i = 0; i < Finfor.allyListObject.Count; i++)
        {
            Finfor.allyListObject[i].atb.Amount = Random.Range(0f, maxATB);;
        }
        for (int i = 0; i < enemyObjectList.Count; i++)
        {
            enemyObjectList[i].atb.Amount = Random.Range(0f, maxATB);;
        }
    }

    public GameObject PlayerFighting;
    public GameObject FujinFighting;
    
    void placeCharacters() // Better to rework this part so characters automatically being counted
    {
        for (int i = 0; i < Finfor.enemyListPrefab.Count; i++)
        {
            CharBat charact = new CharBat();
            charact.atb = new ATB(){ Amount = 0f};
            charact.IsEnemy = true;
            charact.prefabObj = Finfor.enemyListPrefab[i];
            charact.instanceObj = Instantiate(charact.prefabObj);
            // charact.atb = new ATB(){ Amount = 0f, IsEnemy=false};
            charact.instanceObj.transform.position = Pos.getFreeVectEnemy();
            Characters.enemies++;
            enemyObjectList.Add(charact);
        }  


        for (int i = 0; i < Finfor.allyListObject.Count; i++)
        {
            Characters.allies++;
            Finfor.allyListObject[i].textHpObject = Hptext[i];
            Hptext[i].GetComponent<Text>().text = (Finfor.allyListObject[i].instanceObj.GetComponent<IBattle>().Hp).ToString();
            Finfor.allyListObject[i].instanceObj.SetActive(true);
            Finfor.allyListObject[i].instanceObj.transform.position = Pos.getFreeVectAlly();
        }
    }

    public GameObject battleMenu;

    void battleMenuAppear(int index)
    {
        gameObject.GetComponent<AudioSource>().Play(); // menuReadySFX
        Debug.Log("sound played");
        menuAppeared = true;
        BattleMenu script = battleMenu.GetComponent<BattleMenu>();
        script.Activate(index);
    }

    public void resetATB(int atbID)
    {
        Finfor.allyListObject[atbID].atb.Amount = 0f;
    }
}