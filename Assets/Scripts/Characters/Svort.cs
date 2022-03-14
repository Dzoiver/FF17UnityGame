using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CharactersInBattle;

public class Svort : MonoBehaviour, IBattle
{
    public GameObject SvortPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Finfor.enemyList.Add(SvortPrefab);
        Finfor.enemyList.Add(SvortPrefab);
        SceneManager.LoadScene("BattleScene");
    }

    private float hp = 20f;
    private float damage = 10f;

    public float Hp {
        get { return hp; }
        set { hp = value; }
    }

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
        DontDestroyOnLoad(this);
    }

    public float Damage {
        get { return damage; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {   
            Characters.enemies--;
            Destroy(gameObject);
        }
    }

    public void modifyHP()
    {
        Debug.Log("hp rip");
    }

    public float getHP()
    {
        return hp;
    }
        public float getDamage()
    {
        return damage;
    }

    public float Attack(IBattle target)
    {
        return Damage;
    }

    public void Turn(IBattle target)
    {
        
        target.Hp -= Damage;
    }
}
