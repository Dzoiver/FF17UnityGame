using DG.Tweening;
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

    private void Start()
    {
    }
    Transform playerTransform;
    bool attached = false;
    float offset = 0f;

    public void ChangeOffset(float value)
    {
        offset = value;
    }

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

        temp.x = playerTransform.position.x + offset;
        temp.y = playerTransform.position.y + offset;

        transform.position = temp;
    }
}
