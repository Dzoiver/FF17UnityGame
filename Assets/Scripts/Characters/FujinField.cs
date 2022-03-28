using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FujinField : MonoBehaviour, IUsableObjects
{
    public GameObject FujinFighting;
    public GameObject dialogueBox;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        if (Finfor.fujinStarted)
        Destroy(gameObject);
    }

    public void Action()
    {
        string message1 = "I don't want you to get in trouble";
        List<string> list = new List<string>();
        list.Add(message1);
        GameObject dial = Instantiate(dialogueBox, canvas.transform);
        Dialogue script = dial.GetComponent<Dialogue>();
        script.fillPlayDial(list, false);
    }

    // void Awake()
    // {
    //     DontDestroyOnLoad(this);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Finfor.enemyListPrefab.Add(FujinFighting);
        Finfor.enemyListPrefab.Add(FujinFighting);
        Finfor.enemyListPrefab.Add(FujinFighting);
        Finfor.fujinStarted = true;
        Finfor.startVector = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
