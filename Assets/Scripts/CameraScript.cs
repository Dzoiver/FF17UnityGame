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

    public void FindPlayer(GameObject player)
    {
        playerTransform = player.transform;
        attached = true;
    }

    public void Deattach()
    {
        attached = false;
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
