using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyAdder : MonoBehaviour
{
    [SerializeField]
    private HumanPropertyName propertyName;

    [SerializeField]
    private float coefficient;

    [SerializeField]
    private Text text;

    [SerializeField]
    private HumanPropertyManager manager;

    public void OnClicked()
    {
        manager.Property.AddProperty(propertyName, coefficient * int.Parse(text.text));
    }
}
