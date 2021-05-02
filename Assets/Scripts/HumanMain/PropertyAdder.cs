using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 能力値を変化させる。
/// </summary>
public class PropertyAdder : MonoBehaviour
{
    /// <value="propertyName">操作する能力名。</value> 
    [SerializeField]
    private HumanPropertyName propertyName;

    /// <value="coefficient">回数に対する係数。</value> 
    [SerializeField]
    private float coefficient;

    /// <value="text">回数の入ったテキスト。</value> 
    [SerializeField]
    private Text text;

    /// <value="manager">人間の能力値のマネージャー。</value> 
    [SerializeField]
    private HumanPropertyManager manager;

    /// <summary>
    /// クリックしたときのイベントに登録してね。
    /// </summary>
    public void OnClicked()
    {
        manager.Property.AddProperty(propertyName, coefficient * int.Parse(text.text));
    }
}
