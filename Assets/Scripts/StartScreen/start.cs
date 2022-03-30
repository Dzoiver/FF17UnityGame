using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public AudioSource music;
    public GameObject fadeBlack;
    public void LoadStartScene()
    {
        StartCoroutine(startSeq());
        // SceneManager.LoadScene("Town");
    }

    IEnumerator startSeq()
    {
        AudioSource startSFX = gameObject.GetComponent<AudioSource>();
        // music.Stop();
        startSFX.Play(0);
        fadeBlack.GetComponent<FadeBlack>().fade = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Town");
    }

    public void QuitfromGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
