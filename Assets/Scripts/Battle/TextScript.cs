using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    float speed = 0.2f;
    float currentTime = 0.0f;
    float destroyTime = 1.5f;
    Text textComponent;

    void Awake()
    {
        textComponent = GetComponent<Text>();
        // textComponent.color.a;  //  makes a new color zm
        Debug.Log(textComponent.color);
    }
    // Start is called before the first frame update
    void Start()
    {
        // Color32 zm = new Color32(textComponent.color.r, textComponent.color.g, textComponent.color.b, 125); // makes the color zm transparent
        // textComponent.color = zm;
        // Debug.Log(zm);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, destroyTime/currentTime);
        // Debug.Log(destroyTime/currentTime);
        if (currentTime > destroyTime)
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, (destroyTime - currentTime)/destroyTime);
        Debug.Log(destroyTime/currentTime);
        transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
    }
}
