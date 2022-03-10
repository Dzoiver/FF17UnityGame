using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharactersInBattle;

public class Rez : MonoBehaviour, IBattle
{
    public float hp = 250f;
    public float damage = 10f;
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

    public void Attack(Fujin target)
    {
        target.hp -= damage;
    }
}
