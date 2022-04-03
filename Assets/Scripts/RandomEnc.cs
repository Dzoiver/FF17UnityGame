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
    public GameObject fadeImage;
    public AudioSource transitionSFX;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        pScript = playerObject.GetComponent<Playerscript>();
        dangerValue = Random.Range(0, 500);
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
        Color color = new Color(255, 255, 255, 255);
        script.FadeIn(1f, color);
        Playerscript.allowControl = false;
        transitionSFX.Play();
        yield return new WaitForSeconds(script.fadeTime);
        Playerscript.allowControl = true;
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
