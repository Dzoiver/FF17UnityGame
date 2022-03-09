using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rez : MonoBehaviour
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

    void Damage()
    {
        
    }

    public void Attack(Fujin target)
    {
        target.hp -= damage;
    }
}
