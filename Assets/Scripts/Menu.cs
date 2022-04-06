using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    int index = 0;
    int optionsNumber = 3;
    //float shift = 100f;
    // Start is called before the first frame update
    public GameObject selection;
    public GameObject Panel;
    float pos = 0f;
    
    void Start()
    {
        RectTransform rt = selection.GetComponent<RectTransform>();
        pos = selection.transform.position.y;
    }

    public void panelActivate()
    {
        if (!gameObject.activeSelf)
        gameObject.SetActive(true);
        else
        gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("g") && gameObject.activeSelf)
        // {
        //     gameObject.SetActive(false);
        // }

        if (Input.GetKeyDown("s") && gameObject.activeSelf)
        {
            RectTransform rt = selection.GetComponent<RectTransform>();
            selection.transform.position = new Vector3(selection.transform.position.x, pos - rt.rect.height * incIndex(), 0);
        }

        if (Input.GetKeyDown("w") && gameObject.activeSelf)
        {
            RectTransform rt = selection.GetComponent<RectTransform>();
            selection.transform.position = new Vector3(selection.transform.position.x, pos - rt.rect.height * decIndex(), 0);
        }
    }

    int incIndex()
    {
        if (index < optionsNumber - 1 && index >= 0)
        {
        index++;
        return index;
        }
        else
        {
            return index;
        }
    }

    int decIndex()
    {
        if (index < optionsNumber && index > 0)
        {
        index--;
        return index;
        }
        else
        {
            return index;
        }
    }
}
