using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDir : MonoBehaviour
{
    [SerializeField] List<CharacterScriptable> EnemyList;
    [SerializeField] List<CharacterScriptable> AllyList;
    [SerializeField] GameObject[] enemyPositions;
    [SerializeField] GameObject[] allyPositions;

    [SerializeField] GameObject ActionPanel;
    // Start is called before the first frame update
    void Start()
    {
        ActionPanel.SetActive(false);
        PlaceCharacters(EnemyList, AllyList);
        RandomizeATB();
    }

    void PlaceCharacters(List<CharacterScriptable> enemyList, List<CharacterScriptable> allyList)
    {
        int enemies = EnemyList.Count;
        int allies = AllyList.Count;
        // Placing enemies and allies on the battlefield
        for (int i = 0; i < enemyPositions.Length; i++)
        {
            if (i > enemies - 1) // Exit out of the loop if there are less enemies than their positions
                break;
            GameObject enemyObject = Instantiate(enemyList[i].prefab);
            enemyObject.transform.position = enemyPositions[i].transform.position;
        }
        for (int i = 0; i < allyPositions.Length; i++)
        {
            if (i > allies - 1) // Exit out of the loop if there are less allies than their positions
                break;
            GameObject allyObject = Instantiate(allyList[i].prefab);
            allyObject.transform.position = allyPositions[i].transform.position;
        }
    }

    void RandomizeATB()
    {
        for(int i = 0; i < EnemyList.Count; i++)
        {
            EnemyList[i].atb = Random.Range(0f, EnemyList[i].MaxAtb);
        }
        for (int i = 0; i < AllyList.Count; i++)
        {
            AllyList[i].atb = Random.Range(0f, AllyList[i].MaxAtb);
        }
        Debug.Log(EnemyList[0].atb);
        Debug.Log(EnemyList[1].atb);
        Debug.Log(EnemyList[2].atb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
