using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// class Battle
// {
//     GameObject prefab1;
//     GameObject prefab2;
//     GameObject prefab3;

//     public GameObject Prefab 
//     {
//         get { return prefab; }
//         set { prefab = value; }
//     }
// }

public class FujinField : MonoBehaviour
{
    public GameObject FujinFighting;
    // Start is called before the first frame update
    void Start()
    {
        if (Finfor.fujinStarted)
        Destroy(gameObject);
    }

    // void Awake()
    // {
    //     DontDestroyOnLoad(this);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // GameObject fujinObject1 = Instantiate(FujinFighting);
        // GameObject fujinObject2 = Instantiate(FujinFighting);
        // GameObject fujinObject3 = Instantiate(FujinFighting);
        Finfor.enemyListPrefab.Add(FujinFighting);
        Finfor.enemyListPrefab.Add(FujinFighting);
        Finfor.enemyListPrefab.Add(FujinFighting);
        Finfor.fujinStarted = true;
        Finfor.vector = transform.position;
        // SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
