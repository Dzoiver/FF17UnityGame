using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTown : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Playerscript.allowControl = false;
        StartCoroutine(waitTime());
    }
    IEnumerator waitTime()
    {
        FadeBlack script = image.GetComponent<FadeBlack>();
        script.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.allowControl = true;
        Playerscript.lastMap = "WM";
        SceneManager.LoadScene("Town");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
