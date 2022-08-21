using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedScript : MonoBehaviour, IUsableObjects
{
    public void Action()
    {
        InfoBox.instance.Display("Take a rest ?");
    }
}
