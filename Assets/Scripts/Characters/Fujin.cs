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
}
