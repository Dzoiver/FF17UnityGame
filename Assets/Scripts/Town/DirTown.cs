using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirTown : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Finfor.allyList.Add(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
