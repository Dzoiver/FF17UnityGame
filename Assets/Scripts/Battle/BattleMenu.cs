using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    public GameObject cursor;
    float blinkTime = 0.05f;
    float blinkTimeCurrent = 0f;
    int currentATBID;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            Down();
        }
        if (Input.GetKeyDown("w"))
        {
            Up();
        }
        if (Input.GetKeyDown("space") && !locked)
        {
            Select();
        }
        if (Input.GetKeyDown("q"))
        {
            CancelTarget();
        }

        blinkingCursor();
    }

    void blinkingCursor()
    {
        blinkTimeCurrent -= Time.deltaTime;
        if (blinkTimeCurrent < 0)
        {
        BlinkCursor();
        blinkTimeCurrent = blinkTime;
        }
    }

    int maxOptions = 2;
    int currentOption = 0;
    float moveAmount = 0.7f;
    bool blinkCursor = false;
    bool locked = false;
    
    public void Down()
    {
        if (locked)
        return;

        if (currentOption + 1 < maxOptions)
        {
        currentOption++;
        float currentPosY = cursor.transform.position.y;
        float currentPosX = cursor.transform.position.x;
        Vector3 position = new Vector3(currentPosX, currentPosY - moveAmount, 0);
        cursor.transform.position = position;
        }
        else
        {
        currentOption = 0;
        float currentPosY = cursor.transform.position.y;
        float currentPosX = cursor.transform.position.x;
        Vector3 position = new Vector3(currentPosX, currentPosY + moveAmount * (maxOptions - 1), 0);
        cursor.transform.position = position;
        }
    }

    public void Up()
    {
        if (locked)
        return;

        if (currentOption - 1 >= 0)
        {
        currentOption--;
        float currentPosY = cursor.transform.position.y;
        float currentPosX = cursor.transform.position.x;
        Vector3 position = new Vector3(currentPosX, currentPosY + moveAmount, 0);
        cursor.transform.position = position;
        }
        else
        {
        currentOption = maxOptions - 1;
        float currentPosY = cursor.transform.position.y;
        float currentPosX = cursor.transform.position.x;
        Vector3 position = new Vector3(currentPosX, currentPosY - moveAmount, 0);
        cursor.transform.position = position;
        }
    }


    public void Select()
    {
        locked = true;
            switch (currentOption)
        {
            case 0:
                ChooseTarget();
                break;

            case 1:
                MagicListOpen();
                break;
        }
    }

    public GameObject targetHandle;
    void ChooseTarget()
    {
        Target target = targetHandle.GetComponent<Target>(); 
        blinkCursor = true;
        target.Activate(currentATBID);
    }

        void MagicListOpen()
    {
        blinkCursor = true;
    }

    public void CancelTarget()
    {
        Target target = targetHandle.GetComponent<Target>(); 
        locked = false;
        blinkCursor = false;
        target.DeActivate();
        cursor.SetActive(true);
    }

    public void BlinkCursor()
    {
        if (blinkCursor)
        {
            if (cursor.activeSelf)
            {
            cursor.SetActive(false);
            }
            else if (!cursor.activeSelf)
            {
            cursor.SetActive(true);
            }

        }
    }
    public void Activate(int atbID)
    {
        currentATBID = atbID;
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        // reset current id atb
        // currentATBID = atbID;
        locked = false;
        blinkCursor = false;
        gameObject.SetActive(false);
    }
}