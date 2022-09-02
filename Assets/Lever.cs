using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lever : MonoBehaviour, IUsableObjects
{
    [SerializeField] GameObject shaker;
    [SerializeField] GameObject gate;
    public void Action()
    {
        shaker.SetActive(true);
        // Sound
        InfoBox.instance.Display("You hear something opening");
        gate.SetActive(false);
        // gameObject.SetActive(false);
    }
}
