using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChange : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> turnOff;
    [SerializeField]
    private List<GameObject> turnOn;

    public void OnClicked()
    {
        foreach(var off in turnOff)
        {
            off.SetActive(false);
        }

        foreach(var on in turnOn)
        {
            on.SetActive(true);
        }
    }

}
