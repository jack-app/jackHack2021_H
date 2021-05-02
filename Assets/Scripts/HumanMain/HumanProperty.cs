using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人間の能力値のデータ。
/// </summary>
public class HumanProperty
{
    /// <summary>
    /// データのId。
    /// </summary>
    public string Id { get; private set; }

    /// <summary>
    /// 腕の筋肉量。
    /// </summary>
    public float Arm { get; private set; }

    /// <summary>
    /// 腹背筋の筋肉量。
    /// </summary>

    public float Middle { get; private set; }

    /// <summary>
    /// 脚の筋肉量。
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
    /// 能力値を変化させる。
    /// </summary>
    /// <param name="property">変化させる能力値。</param>
    /// <param name="add">加算する量。</param>
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
/// 能力値の名前。
/// </summary>
public enum HumanPropertyName
{
    Arm,
    Middle,
    Leg
}
