using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Positions;
using UnityEngine.SceneManagement;
using DG.Tweening;

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

    [SerializeField] GameObject destinationPoint;
    [SerializeField] GameObject startPoint;
    [SerializeField] FadeBlack fadeImageScript;
    [SerializeField] CharacterScriptable player;

    void Start()
    {
        if (CharactersScript.instance.MembersNumber == 0)
        CharactersScript.instance.Add(player);
        Playerscript.instance.allowControl = false;
        CameraScript.instance.FindPlayer();
        SetPlayerLocation();
    }

    private void SetPlayerLocation()
    {
        if (Finfor.instance.lastField == "") // Init player if there's none
        {
            Playerscript.instance.gameObject.transform.position = startPoint.transform.position;
            StartCoroutine(fadeAndWait());
        }
        else if (Finfor.instance.lastField == "WM")
        {
            StartCoroutine(fadeWaitTimeAfterWM());
            Playerscript.instance.gameObject.transform.position = destinationPoint.transform.position;
        }

        Finfor.instance.lastField = "Town";
    }

    IEnumerator fadeWaitTimeAfterWM()
    {
        fadeImageScript.FadeOut(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
    }

    IEnumerator fadeAndWait()
    {
        fadeImageScript.FadeOut(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
    }
}
