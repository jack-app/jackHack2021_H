using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �l�Ԃ̔\�͒l�̃f�[�^�B
/// </summary>
public class HumanProperty
{
    /// <summary>
    /// �f�[�^��Id�B
    /// </summary>
    public string Id { get; private set; }

    /// <summary>
    /// �r�̋ؓ��ʁB
    /// </summary>
    public float Arm { get; private set; }

    /// <summary>
    /// ���w�؂̋ؓ��ʁB
    /// </summary>

    public float Middle { get; private set; }

    /// <summary>
    /// �r�̋ؓ��ʁB
    /// </summary>
    public float Leg { get; private set; }

    public HumanProperty(string id)
    {
        Id = id;
        Arm = 0;
        Middle = 0;
        Leg = 0;
    }

    /// <summary>
    /// �\�͒l��ω�������B
    /// </summary>
    /// <param name="property">�ω�������\�͒l�B</param>
    /// <param name="add">���Z����ʁB</param>
    public void AddProperty(HumanPropertyName property, float add)
    {
        switch (property) {
            case HumanPropertyName.Arm: Arm += add; break;
            case HumanPropertyName.Middle: Middle += add; break;
            case HumanPropertyName.Leg: Leg += add; break;
        }
    }
}

/// <summary>
/// �\�͒l�̖��O�B
/// </summary>
public enum HumanPropertyName
{
    Arm,
    Middle,
    Leg
}
