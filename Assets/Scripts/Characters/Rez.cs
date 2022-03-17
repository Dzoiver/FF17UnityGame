using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharactersInBattle;
using UnityEngine.UI;

public class Rez : MonoBehaviour, IBattle
{
    private float hp = 250f;
    float damage = 60f;

    public float Hp {
        get { return hp; }
        set { 
            hp = value;
            if (Hp <= 0)
            Destroy(gameObject);
            }
    }

    private int index;
    public int Index {
        get { return Index; }
        set { Index = value; }
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
    }

    public float Attack(IBattle target)
    {
        float procDamage = Random.Range(-5, 5) + damage;
        target.Hp -= procDamage;
        return procDamage;
    }
}
