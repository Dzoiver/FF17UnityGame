using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour, IBattle
{
    private float Damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float Attack(IBattle target)
    {
        return Damage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
