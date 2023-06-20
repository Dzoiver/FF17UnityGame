using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class RandomEnc : MonoBehaviour
{
    [SerializeField] CharacterScriptable svort;
    [SerializeField] GameObject fadeImage;
    [SerializeField] AudioSource transitionSFX;
    [SerializeField] GameObject DP;
    public bool EnableEncounters = true;

    private float dangerValue;
    private int formation;
    Color whiteColorTransparent = new Color(1f, 1f, 1f, 0f);
    Color blackColorTransparent = new Color(0f, 0f, 0f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        dangerValue = Random.Range(100, 500);
        Playerscript.instance.dangerDistance = 0;
    }

    private void StepCountBattle()
    {
        Playerscript.instance.dangerDistance = 0;
        formation = Random.Range(1, 4);
        dangerValue = Random.Range(0, 500);
        Debug.Log("formation: " + formation);
        for (int i = 0; i < formation; i++)
        {
            Finfor.enemyListScriptable.Add(svort); // Enemy from current location enemies object
            Debug.Log("spawned");
        }
        Playerscript.instance.allowControl = false;
        Image image = fadeImage.GetComponent<Image>();
        image.DOColor(whiteColorTransparent, 0);
        transitionSFX.Play();
        image.DOFade(1f, 1f).onComplete = () =>
        {
            image.DOColor(blackColorTransparent, 0.5f).onComplete = () =>
            {
                Playerscript.instance.allowControl = true;
                Finfor.instance.startVector = Playerscript.instance.gameObject.transform.position;
                SceneManager.LoadScene("BattleScene");
            };
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnableEncounters)
            return;
        if (Playerscript.instance.dangerDistance > dangerValue)
        {
            StepCountBattle();
        }
    }
}
