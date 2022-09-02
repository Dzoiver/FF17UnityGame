using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // AppMetrica.Instance.ReportAppOpen("");
        string eventParameters = "{\"name\":\"Alice\", \"age\":\"18\"}";
        AppMetrica.Instance.ReportEvent("haha dima pepapupa");
        //AppMetrica.Instance.ActivateWithConfiguration()

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
