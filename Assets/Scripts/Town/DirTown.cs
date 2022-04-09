using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;
using UnityEngine.SceneManagement;

public class DirTown : MonoBehaviour
{
    public GameObject destinationPoint;
    public GameObject image;
    public CharacterScriptable player;
    public GameObject startPoint;

    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene("Crypt");

        if (Playerscript.lastMap == "WM")
        {
            Playerscript.allowControl = false;
            StartCoroutine(waitTimeAfterWM());
            GameObject.FindWithTag("Player").transform.position = destinationPoint.transform.position;
        }
        else
        {
            CharactersScript.instance.Add(player);
            GameObject playerObject = Instantiate(player.prefab);
            playerObject.transform.position = startPoint.transform.position;
            CameraScript.instance.FindPlayer(playerObject);
            
            Playerscript.allowControl = false;
            StartCoroutine(waitTime());
        }
        Playerscript.lastMap = "Town";
    }

    IEnumerator waitTimeAfterWM()
    {
        FadeBlack script = image.GetComponent<FadeBlack>();
        script.FadeOut(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.allowControl = true;
    }

    IEnumerator waitTime()
    {
        FadeBlack script = image.GetComponent<FadeBlack>();
        script.FadeOut(3f);
        yield return new WaitForSeconds(4f);
        Playerscript.allowControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
