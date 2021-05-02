using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャンバスを変えるクラス。
/// </summary>
public class CanvasChange : MonoBehaviour
{
    /// <value="turnOff">見えなくするキャンパス。</value>
    [SerializeField]
    private List<GameObject> turnOff;

    /// <value="turnOn">見えるようにするキャンパス。</value>
    [SerializeField]
    private List<GameObject> turnOn;


    /// <summary>
    /// クリックしたときのイベントに登録してね。
    /// </summary>
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
