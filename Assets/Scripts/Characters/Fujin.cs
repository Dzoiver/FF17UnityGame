using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharactersInBattle;

public class Fujin : MonoBehaviour, IBattle
{
    public float hp = 200f;
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
