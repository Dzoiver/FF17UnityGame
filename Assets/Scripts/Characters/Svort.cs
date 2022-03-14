using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Svort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Finfor.enemyList.Add(gameObject);
        SceneManager.LoadScene("BattleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
