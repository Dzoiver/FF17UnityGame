using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCrypt : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Playerscript.instance.allowControl = false;
        StartCoroutine(waitTime());
    }

    IEnumerator waitTime()
    {
        FadeBlack script = image.GetComponent<FadeBlack>();
        script.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        Playerscript.instance.allowControl = true;
        Finfor.instance.lastField = "WM";
        SceneManager.LoadScene("Crypt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
