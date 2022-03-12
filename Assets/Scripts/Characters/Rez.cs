using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharactersInBattle;

public class Rez : MonoBehaviour, IBattle
{
    private float hp = 250f;
    float damage = 10f;

    public float Hp {
        get { return hp; }
        set { hp = value; }
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

    public float getDamage()
    {
        return damage;
    }

    public float getHP()
    {
        return hp;
    }

    public float Attack(IBattle target)
    {
        float procDamage = Random.Range(-5, 5) + damage;
        target.Hp -= procDamage;
        return procDamage;
    }
}
