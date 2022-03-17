using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharactersInBattle;

public class Fujin : MonoBehaviour, IBattle
{
    private float hp = 40f;
    private float damage = 10f;

    public float Hp {
        get { return hp; }
        set { hp = value; }
    }

    private int index;
        public int Index {
        get { return Index; }
        set { Index = value; }
    }

    void Awake()
    {
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
            // Characters.objectEnemyList.RemoveAt(index);
            Destroy(gameObject);
        }
    }

    public float Attack(IBattle target)
    {
        Debug.Log("Fujin attacked");
        float procDamage = Random.Range(-5, 5) + damage;
        target.Hp -= procDamage;
        return procDamage;
    }

    public void Turn(IBattle target)
    {
        
        target.Hp -= Damage;
    }
}
