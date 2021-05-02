using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �\�͒l��ω�������B
/// </summary>
public class PropertyAdder : MonoBehaviour
{
    /// <value="propertyName">���삷��\�͖��B</value> 
    [SerializeField]
    private HumanPropertyName propertyName;

    /// <value="coefficient">�񐔂ɑ΂���W���B</value> 
    [SerializeField]
    private float coefficient;

    /// <value="text">�񐔂̓������e�L�X�g�B</value> 
    [SerializeField]
    private Text text;

    /// <value="manager">�l�Ԃ̔\�͒l�̃}�l�[�W���[�B</value> 
    [SerializeField]
    private HumanPropertyManager manager;

    /// <summary>
    /// �N���b�N�����Ƃ��̃C�x���g�ɓo�^���ĂˁB
    /// </summary>
    public void OnClicked()
    {
        manager.Property.AddProperty(propertyName, coefficient * int.Parse(text.text));
    }
}
