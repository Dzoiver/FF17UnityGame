using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptDir : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Playerscript.lastMap = "Crypt";
        // allyListPrefab.Add(player);
        // for (int i = 0; i < allyListPrefab.Count; i++)
        // {
        //     Debug.Log("creating player objects");
        //     // atbList.Add(new ATB(){ Amount = 0f, IsEnemy=true});
        //     CharBat charact = new CharBat();
        //     charact.atb = new ATB(){ Amount = 0f};
        //     charact.IsEnemy = false;
        //     charact.prefabObj = allyListPrefab[i];
        //     charact.instanceObj = Instantiate(charact.prefabObj);
        //     // charact.atb = new ATB(){ Amount = 0f, IsEnemy=false};

        //     allyListObject.Add(charact);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
