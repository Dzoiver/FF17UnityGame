using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticClass {
    public static string CrossSceneInformation { get; set; }
}

public class Director : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Finfor.allyList.Add(playerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
