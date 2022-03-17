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

    // Spot spotObj;
    // public Spot SpotObj 
    // {
    //     get { return spotObj; }
    //     set { spotObj = value; }
    // }
    // Position pos;
    // Position pos;
}

// class Fujin : Character
// {

// }

public class BattleDirector : MonoBehaviour
{
    static public List<CharBat> characterList = new List<CharBat>(); // List of all characters in a battle including enemies

    float maxATB = 30f; // Max value of ATB
    float atbSpeed = 10f; // Speed of the ATB bar
    bool menuAppeared = false; // Prevents several menu from stacking on the screen
    bool end = false; // Set to true when all enemies slain
    public GameObject Hpbar; // Ally health text object
    CharBat charact;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public List<GameObject> Hptext = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
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

    // void fillATBlist()
    // {
    //     for (int i = 0; i < Characters.enemies; i++)
    //     {
    //         atbList.Add(new ATB(){ Amount = 0f, IsEnemy=true});
    //     }
    //     for (int i = Characters.enemies; i < Characters.allies + Characters.enemies; i++)
    //     {
    //         atbList.Add(new ATB(){ Amount = 0f, IsEnemy=false});
    //     }
    // }

    public GameObject victory; 
    public GameObject music; 

    void EndBattle()
    {
        characterList.Clear();
        Finfor.enemyList.Clear();
        Characters.objectEnemyList.Clear();
        Characters.objectAllyList.Clear();
        if (Characters.enemies == 0)
        {
        StartCoroutine(waiter());
        }
        else if (Characters.allies == 0)
        {
        StartCoroutine(loosing());
        }
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

    public GameObject lose; 
    IEnumerator loosing()
    {
    Debug.Log("playing lose music");
    end = true;
    AudioSource lose1 = lose.GetComponent<AudioSource>();
    AudioSource music1 = music.GetComponent<AudioSource>();
    music1.Stop();
    lose1.Play(0);
    yield return new WaitForSeconds(5);
    }

    public void ChangeATB()
    {
        // float currentHealth = Mathf.Clamp(allyATB_1 + value, 0, maxATB);
        for (int i = 0; i < characterList.Count; i++)
        {
            if (!characterList[i].IsEnemy)
            UIATB.instance.SetValue(characterList[i].atb.Amount / (float)maxATB);
        }
        
    }
    public GameObject damageTextPrefab;

    void fillATBs(float rate)
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].atb.Amount += rate;
            if (characterList[i].atb.IsReady && !characterList[i].IsEnemy)
            {
                battleMenuAppear(i);
            }

            else if (characterList[i].atb.IsReady && characterList[i].IsEnemy && characterList[i].Alive)
            {
                // Debug.Log(BattleDirector.characterList[1].instanceObj.GetComponent<IBattle>() + " Debug.Log(BattleDirector.characterList[i]); i:" + i);
                IBattle attackerScript = BattleDirector.characterList[i].instanceObj.GetComponent<IBattle>();

                int randomAllyIndex = getRandomAllyIndex();
                IBattle targetScript = characterList[randomAllyIndex].instanceObj.GetComponent<IBattle>();
                float dmg = attackerScript.Attack(targetScript);
                // GameObject fujinObject = Instantiate(FujinFighting); 
                // GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
                // Projectile projectile = projectileObject.GetComponent<Projectile>();
                // projectile.Launch(lookDirection, 300);
                // animator.SetTrigger("Launch");
                StartCoroutine(enemyAttackAnim());
                GameObject textObject = Instantiate(damageTextPrefab, transform, false);
                textObject.transform.position = characterList[randomAllyIndex].instanceObj.transform.position;
                Text hptext = characterList[randomAllyIndex].textHpObject.GetComponent<Text>();
                hptext.text = (int.Parse(hptext.text) - dmg).ToString();
                
                Text text = textObject.GetComponent<Text>();
                text.text = "-" + dmg;
                textObject.SetActive(true);
                // rez.Attack(fujin);
                
                if (targetScript.Hp <= 0)
                {
                BattleDirector.characterList[randomAllyIndex].Alive = false;
                Pos.positionsList[randomAllyIndex].IsEmpty = false;
                }
                BattleDirector.characterList[i].atb.IsReady = false;
                BattleDirector.characterList[i].atb.Amount = 0f;
            }
        }

        ChangeATB();
    }

    IEnumerator enemyAttackAnim()
    {
    yield return new WaitForSeconds(2);
    }

    int getRandomAllyIndex()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < characterList.Count; i++)
        {
            Debug.Log("characterList.Count " + characterList.Count);
            if (characterList[i].Alive && !characterList[i].IsEnemy) 
            {
                list.Add(i);
            }
        } 
        return Random.Range(list[0], list[list.Count - 1]);
    }

    void randomInitialATB()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            // characterList[i].atb.Amount = 25f;
            characterList[i].atb.Amount = Random.Range(0f, maxATB);;
        }
    }

    public GameObject PlayerFighting;
    public GameObject FujinFighting;
    
    void placeCharacters() // Better to rework this part so characters automatically being counted
    {
        for (int i = 0; i < Finfor.enemyList.Count; i++)
        {
            CharBat charact = new CharBat();
            charact.atb = new ATB(){ Amount = 0f};
            charact.IsEnemy = true;
            charact.prefabObj = Finfor.enemyList[i];
            charact.instanceObj = Instantiate(charact.prefabObj);
            // charact.atb = new ATB(){ Amount = 0f, IsEnemy=false};
            charact.instanceObj.transform.position = Pos.getFreeVectEnemy();
            Characters.enemies++;
            characterList.Add(charact);
        }  

        for (int i = 0; i < Finfor.allyList.Count; i++)
        {
            // atbList.Add(new ATB(){ Amount = 0f, IsEnemy=true});
            CharBat charact = new CharBat();
            charact.textHpObject = Hptext[i];
            charact.atb = new ATB(){ Amount = 0f};
            charact.IsEnemy = false;
            charact.prefabObj = Finfor.allyList[i];
            charact.instanceObj = Instantiate(charact.prefabObj);
            Characters.allies++;
            charact.textHpObject = Hptext[i];
            // charact.atb = new ATB(){ Amount = 0f, IsEnemy=false};
            charact.instanceObj.transform.position = Pos.getFreeVectAlly();

            characterList.Add(charact);
        }
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
        characterList[atbID].atb.Amount = 0f;
    }
}