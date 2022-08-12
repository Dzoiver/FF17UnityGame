using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;
using UnityEngine.SceneManagement;

public class DirTown : MonoBehaviour
{
    #region Singleton
    public static DirTown instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of CameraScript found!");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject destinationPoint;
    public GameObject fadeImage;
    public CharacterScriptable player;
    [SerializeField] GameObject newGamePoint;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerLocation();
    }

    private void SetPlayerLocation()
    {
        if (Playerscript.instance == null) // Init player if there's none
        {
            CharactersScript.instance.Add(player);
            GameObject playerObject = Instantiate(player.prefab);
            playerObject.transform.position = newGamePoint.transform.position;
            CameraScript.instance.FindPlayer(playerObject);

            Playerscript.instance.allowControl = false;
            StartCoroutine(fadeAndWait());
        }
        else if (Playerscript.instance.lastMap == "WM")
        {
            Playerscript.instance.allowControl = false;
            StartCoroutine(fadeWaitTimeAfterWM());
            GameObject.FindWithTag("Player").transform.position = destinationPoint.transform.position;
        }

        Playerscript.instance.lastMap = "Town";
    }

    IEnumerator fadeWaitTimeAfterWM()
    {
        FadeBlack fadeScript = fadeImage.GetComponent<FadeBlack>();
        fadeScript.FadeOut(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
    }

    IEnumerator fadeAndWait()
    {
        FadeBlack script = fadeImage.GetComponent<FadeBlack>();
        script.FadeOut(3f);
        yield return new WaitForSeconds(4f);
        Playerscript.instance.allowControl = true;
    }
}
