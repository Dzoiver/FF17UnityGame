using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rez : MonoBehaviour, IBattle
{
    private float hp = 250f;
    float damage = 60f;
    private bool stepUp;
    public bool StepUp {
        get { return StepUp; }
        set { StepUp = value; }
    }
    private bool backup;
    public bool Backup {
        get { return Backup; }
        set { Backup = value; }
    }

    public float Hp {
        get { return hp; }
        set { 
            hp = value;
            if (Hp <= 0)
            gameObject.SetActive(false);
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
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float Attack(IBattle target)
    {
        float procDamage = Random.Range(-5, 5) + damage;
        return procDamage;
    }
}
