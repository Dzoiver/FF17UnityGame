using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMDir : MonoBehaviour
{
    [SerializeField] GameObject cryptPos;
    [SerializeField] GameObject townPos;
    public GameObject image;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (Finfor.instance == null)
        {
            GameObject playerObject = Instantiate(player);
            playerObject.transform.position = townPos.transform.position;
            return;
        }
        Playerscript.instance.allowControl = false;
        StartCoroutine(waitTime());
        if (Finfor.instance.lastField == "Crypt")
        {
            CharactersScript.instance.PlaceCharacter(cryptPos.transform);
        }
        if (Finfor.instance.lastField == "Town")
        {
            CharactersScript.instance.PlaceCharacter(townPos.transform);
        }
        Finfor.instance.lastField = "WM";
    }

    IEnumerator waitTime()
    {
        FadeBlack script = image.GetComponent<FadeBlack>();
        script.FadeOut(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
    }
}
