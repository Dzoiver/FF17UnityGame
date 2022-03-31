using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToWM : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(waitTime());
    }
    IEnumerator waitTime()
    {
        Playerscript.allowControl = false;
        FadeBlack fading = image.GetComponent<FadeBlack>();
        fading.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.allowControl = true;
        SceneManager.LoadScene("WM");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
