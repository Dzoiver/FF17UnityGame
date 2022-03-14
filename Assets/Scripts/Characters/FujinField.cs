using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FujinField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Finfor.fujinStarted)
        Destroy(gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Finfor.fujinStarted = true;
        Finfor.vector = transform.position;
        SceneManager.LoadScene("BattleScene");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
