using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finfor : MonoBehaviour
{
    static public float hp = 250f;
    public static Vector3 vector = new Vector3(2, 0 , 0);
    public static bool isFujin = true;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
