using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FujinChar : MonoBehaviour
{
    // Start is called before the first frame upda

    void Start()
    {
        if (!Finfor.isFujin)
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
