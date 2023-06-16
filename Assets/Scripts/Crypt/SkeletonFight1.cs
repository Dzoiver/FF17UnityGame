using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonFight1 : MonoBehaviour
{
    [SerializeField] GameObject cameraFocusPoint;
    [SerializeField] DialogueScriptable dialogue1;
    [SerializeField] Sprite sprite;
    [SerializeField] CharacterScriptable skeleton;
    [SerializeField] FadeBlack fadeblackScript;
    [SerializeField] AudioSource transitionSFX;

    float cameraSpeed = 4f;
    bool cameraReached = false;
    bool startCamera = false;
    Color color = new Color(255, 255, 255, 1);
    Color color1 = new Color(1, 1, 1, 1);
    Color color2 = new Color(0, 0, 0, 1);
    private void OnTriggerEnter2D(Collider2D other)
    {
        startCamera = true;
        Playerscript.instance.allowControl = false;
        CameraScript.instance.Deattach();
    }

    IEnumerator ScriptedBattle()
    {
        Finfor.enemyListScriptable.Add(skeleton);
        Finfor.enemyListScriptable.Add(skeleton);
        Finfor.enemyListScriptable.Add(skeleton);
        fadeblackScript.FadeIn(1f, color);
        Playerscript.instance.allowControl = false;
        transitionSFX.Play();
        // Make black fade
        fadeblackScript.FadeIn(1f, color);
        yield return new WaitForSeconds(fadeblackScript.fadeTime);
        fadeblackScript.FadeColor(0.5f, color1, color2);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
        Finfor.instance.startVector = Playerscript.instance.transform.position;
        SceneManager.LoadScene("BattleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (startCamera && !cameraReached)
        {
            Vector3 vectorMove = Vector3.MoveTowards(CameraScript.instance.transform.position,
                cameraFocusPoint.transform.position, Time.deltaTime * cameraSpeed);

            CameraScript.instance.transform.position = vectorMove;
            if (cameraFocusPoint.transform.position == CameraScript.instance.transform.position)
            {
                cameraReached = true;
                DialogueManager.instance.fillPlayDial(dialogue1.messages, false, sprite);
            }
        }
        else if (!DialogueManager.instance.Play && startCamera)
        {
            StartCoroutine(ScriptedBattle());
            startCamera = false;
        }
        
    }
}
