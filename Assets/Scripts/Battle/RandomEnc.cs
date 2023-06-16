using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEnc : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CharacterScriptable svort;
    [SerializeField] GameObject fadeImage;
    [SerializeField] AudioSource transitionSFX;
    [SerializeField] GameObject DP;
    public bool EnableEncounters = true;

    private float dangerValue;
    private int formation;
    Playerscript pScript;
    Color color = new Color(255, 255, 255, 1);
    Color color1 = new Color(1, 1, 1, 1);
    Color color2 = new Color(0, 0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        pScript = playerObject.GetComponent<Playerscript>();
        dangerValue = Random.Range(100, 500);
    }

    IEnumerator StepCountBattle()
    {
        formation = Random.Range(1, 3);
        dangerValue = Random.Range(0, 500);
        pScript.dangerDistance = 0;
        for (int i = 0; i < formation; i++)
        {
            Finfor.enemyListScriptable.Add(svort); // Enemy from current location enemies object
        }
        FadeBlack script = fadeImage.GetComponent<FadeBlack>();
        script.FadeIn(1f, color);
        Playerscript.instance.allowControl = false;
        transitionSFX.Play();
        // Make black fade
        script.FadeIn(1f, color);
        yield return new WaitForSeconds(script.fadeTime);
        script.FadeColor(0.5f, color1, color2);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
        Finfor.instance.startVector = player.transform.position;
        SceneManager.LoadScene("BattleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnableEncounters)
            return;
        if (pScript.dangerDistance > dangerValue)
        {
            StartCoroutine(StepCountBattle());
        }
    }
}