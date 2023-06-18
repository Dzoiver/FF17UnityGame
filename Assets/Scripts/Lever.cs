using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lever : MonoBehaviour, IUsableObjects
{
    [SerializeField] GameObject shaker;
    [SerializeField] GameObject gate;
    AudioSource leverSFX;

    private void Start()
    {
        if (Finfor.instance.progress >= 3)
        {
            gate.SetActive(false);
        }
        leverSFX = GetComponent<AudioSource>();
    }
    public void Action()
    {
        if (Finfor.instance.progress < 3)
        {
            shaker.SetActive(true);
            leverSFX.Play();
            Finfor.instance.progress = 3;
            InfoBox.instance.Display("You hear something opening");
            gate.SetActive(false);
        }
    }
}
