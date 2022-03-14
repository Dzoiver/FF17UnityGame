using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FujinTrigger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (Finfor.fujinStarted)
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
