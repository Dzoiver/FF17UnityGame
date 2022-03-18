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
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > destroyTime)
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, (destroyTime - currentTime)/destroyTime);
        transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
    }
}
