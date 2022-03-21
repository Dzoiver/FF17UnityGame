using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEnc : MonoBehaviour
{
    Transform playerTransform;
    float dangerValue;
    Playerscript pScript;
    int formation;
    public GameObject SvortPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        pScript = playerObject.GetComponent<Playerscript>();
        dangerValue = Random.Range(0, 500);
        formation = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (pScript.distance > dangerValue)
        {
            dangerValue = Random.Range(0, 500);
            pScript.distance = 0;
            for (int i = 0; i < formation; i++)
            {
                Finfor.enemyListPrefab.Add(SvortPrefab);
            }
            formation = Random.Range(1, 3);
            SceneManager.LoadScene("BattleScene");
        }
    }
}
