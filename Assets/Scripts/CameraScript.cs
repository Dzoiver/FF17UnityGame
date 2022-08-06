using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    #region Singleton
    public static CameraScript instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of CameraScript found!");
            return;
        }
        instance = this;
    }
    #endregion

    Transform playerTransform;
    bool attached = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        FindPlayer(player);
    }

    public void FindPlayer(GameObject player)
    {
        playerTransform = player.transform;
        attached = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() {
        if (!attached)
        return;

        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        transform.position = temp;
    }
}
