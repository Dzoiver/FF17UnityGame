using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    float timer = 2f;
    float currentTime = 0f;
    float interval = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < timer)
        {
            CameraScript.instance.ChangeOffset(Random.Range(-0.05f, 0.05f));
        }
        else
        {
            CameraScript.instance.ChangeOffset(0);
            CameraScript.instance.FindPlayer(Playerscript.instance.gameObject);
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;
    }
}
