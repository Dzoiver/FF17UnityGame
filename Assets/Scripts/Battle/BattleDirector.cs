using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Positions;
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
    public bool stepUp = false;
    public bool backUp = false;
    public float hp = 0;

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

public class BattleDirector : MonoBehaviour
{
    static public List<CharBat> enemyObjectList = new List<CharBat>(); // List of all characters in a battle including enemies ???
    public bool menuAppeared = false; // Prevents several menu from stacking on the screen
    public bool isPlayerActing = false;

    private float maxATB = 30f; // Max value of ATB
    private float atbSpeed = 10f; // Speed of the ATB bar
    private bool end = false; // Set to true when all enemies slain
    private bool activeTurn = false;

    private int alliesCount = 0;

    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] FadeBlack fadeScript;
    public List<GameObject> Hptext = new List<GameObject>();

    [SerializeField] GameObject victory;
    [SerializeField] GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        Playerscript.instance.gameObject.SetActive(false);
        fadeScript.FadeOut(1f);
        Hptext.Add(text3);
        Hptext.Add(text2);
        Hptext.Add(text1);

        Pos.createAllpos(); // Creates positions for characters
        PlaceCharacters();
        RandomInitialATB();
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

    void EndBattle()
    {
        Finfor.enemyListScriptable.Clear();
        Characters.objectAllyList.Clear();
        if (Characters.enemies == 0)
        {
            StartCoroutine(VictoryEnd());
        }
        else if (alliesCount == 0)
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
        enemyObjectList.Clear();
        Characters.objectEnemyList.Clear();
        Playerscript.instance.gameObject.SetActive(true);
        SceneManager.LoadScene(Finfor.instance.lastField);
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
        Characters.objectEnemyList.Clear();
        Finfor.instance.progress = 0;
        Destroy(Finfor.instance.gameObject);
        Destroy(CharactersScript.instance.gameObject);
        Destroy(Menu.instance.gameObject);
        Finfor.allyListScriptable.Clear();
        enemyObjectList.Clear();
        // SceneManager.LoadScene("StartScreen");
    }

    public void ChangeATB()
    {
        for (int i = 0; i < Finfor.allyListObject.Count; i++)
        {
            UIATB.instance.SetValue(Finfor.allyListObject[i].atb.Amount / (float)maxATB);
        }
    }
    public GameObject damageTextPrefab;
    public GameObject targetHandle;

    void fillATBs(float rate) // Fill ALL charcaters ATB
    {
        if (activeTurn || isPlayerActing)
        return;

        for (int i = 0; i < Finfor.allyListObject.Count; i++) // Allies first
        {
            Finfor.allyListObject[i].atb.Amount += rate;
            if (Finfor.allyListObject[i].atb.IsReady && !menuAppeared)
            {
                BattleMenuAppear(i); // If ready, menu appears
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

    IEnumerator TurnAnimation(int i) // Enemy attack
    {
        activeTurn = true; // Block other turns while current happens

        int randomAllyIndex = GetRandomAllyIndex();
        enemyObjectList[i].stepUp = true;
        yield return new WaitForSeconds(0.4f);

        float dmg = Finfor.enemyListScriptable[i].damage;

        GameObject textObject = Instantiate(damageTextPrefab, targetHandle.transform, false);
        textObject.transform.position = Finfor.allyListObject[randomAllyIndex].instanceObj.transform.position;
        Text hptext = Finfor.allyListObject[randomAllyIndex].textHpObject.GetComponent<Text>();
        hptext.text = (int.Parse(hptext.text) - dmg).ToString(); // Text update
        
        Text text = textObject.GetComponent<Text>();
        text.text = "-" + dmg;
        textObject.SetActive(true); // DMG number appear
        Finfor.allyListObject[randomAllyIndex].hp -= dmg;
        
        if (Finfor.allyListObject[randomAllyIndex].hp <= 0) // Check whether the player is dead after hit
        {
            Finfor.allyListObject[randomAllyIndex].Alive = false;
            Pos.positionsList[randomAllyIndex].IsEmpty = true;
            alliesCount--;
            if (Characters.allies <= 0)
            {
                EndBattle();
            }
        }
        yield return new WaitForSeconds(0.4f);
        if (i >= 0)
        {
            enemyObjectList[i].backUp = true;
            enemyObjectList[i].atb.IsReady = false;
            enemyObjectList[i].atb.Amount = 0f;
        }
        activeTurn = false;
    }

    int GetRandomAllyIndex()
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

    void RandomInitialATB()
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
    
    void PlaceCharacters() // Better to rework this part so characters automatically being counted
    {
        for (int i = 0; i < Finfor.enemyListScriptable.Count; i++)
        {
            CharBat charact = new CharBat();
            charact.atb = new ATB(){ Amount = 0f};
            charact.IsEnemy = true;
            charact.prefabObj = Finfor.enemyListScriptable[i].prefab;
            charact.instanceObj = Instantiate(charact.prefabObj);
            charact.instanceObj.transform.position = Pos.getFreeVectEnemy();
            Characters.enemies++;
            enemyObjectList.Add(charact);
        }  


        for (int i = 0; i < Finfor.allyListObject.Count; i++)
        {
            alliesCount++;
            Finfor.allyListObject[i].textHpObject = Hptext[i];
            Hptext[i].GetComponent<Text>().text = (Finfor.allyListObject[i].hp).ToString();
            var allyIntance = Instantiate(Finfor.allyListScriptable[i].prefab);
            Finfor.allyListObject[i].instanceObj = allyIntance;
            allyIntance.transform.position = Pos.getFreeVectAlly();
        }
    }

    public GameObject battleMenu;

    void BattleMenuAppear(int index)
    {
        gameObject.GetComponent<AudioSource>().Play(); // menuReadySFX
        menuAppeared = true;
        BattleMenu script = battleMenu.GetComponent<BattleMenu>();
        script.Activate(index);
    }

    public void ResetATB(int atbID)
    {
        Finfor.allyListObject[atbID].atb.Amount = 0f;
    }
}