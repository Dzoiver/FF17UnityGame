using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEnc : MonoBehaviour
{
    public GameObject player;
    float dangerValue;
    Playerscript pScript;
    int formation;
    public GameObject SvortPrefab;
    public GameObject fadeImage;
    public AudioSource transitionSFX;
    public GameObject DP;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        pScript = playerObject.GetComponent<Playerscript>();
        dangerValue = Random.Range(100, 500);
        formation = Random.Range(1, 3);
    }

    IEnumerator Battle()
    {
        dangerValue = Random.Range(0, 500);
        pScript.distance = 0;
        for (int i = 0; i < formation; i++)
        {
            Finfor.enemyListPrefab.Add(SvortPrefab); // Enemy from current location enemies object
        }
        formation = Random.Range(1, 3);
        FadeBlack script = fadeImage.GetComponent<FadeBlack>();
        Color color = new Color(255, 255, 255, 1);
        script.FadeIn(1f, color);
        Playerscript.allowControl = false;
        transitionSFX.Play();
        // Make black fade
        script.FadeIn(1f, color);
        yield return new WaitForSeconds(script.fadeTime);
        Color color1 = new Color(1, 1, 1, 1);
        Color color2 = new Color(0, 0, 0, 1);
        script.FadeColor(0.5f, color1, color2);
        yield return new WaitForSeconds(1f);
        Playerscript.allowControl = true;
        Finfor.startVector = player.transform.position;
        SceneManager.LoadScene("BattleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (pScript.distance > dangerValue)
        {
            StartCoroutine(Battle());
        }
    }
}
