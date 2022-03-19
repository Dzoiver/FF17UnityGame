using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBox : MonoBehaviour
{
    float deathTime = 2.0f;
    float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Display()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > deathTime)
        Destroy(gameObject);
    }
}
