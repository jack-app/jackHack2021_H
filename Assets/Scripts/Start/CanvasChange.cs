using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �L�����o�X��ς���N���X�B
/// </summary>
public class CanvasChange : MonoBehaviour
{
    /// <value="turnOff">�����Ȃ�����L�����p�X�B</value>
    [SerializeField]
    private List<GameObject> turnOff;

    /// <value="turnOn">������悤�ɂ���L�����p�X�B</value>
    [SerializeField]
    private List<GameObject> turnOn;


    /// <summary>
    /// �N���b�N�����Ƃ��̃C�x���g�ɓo�^���ĂˁB
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
