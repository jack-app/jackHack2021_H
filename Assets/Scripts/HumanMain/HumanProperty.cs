using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanProperty
{
    public string Id { get; private set; }
    public float Arm { get; private set; }

    public float Middle { get; private set; }
    public float Leg { get; private set; }

    public HumanProperty(string id)
    {
        Id = id;
        Arm = 0;
        Middle = 0;
        Leg = 0;
    }

    public void AddProperty(HumanPropertyName property, float add)
    {
        switch (property) {
            case HumanPropertyName.Arm: Arm += add; break;
            case HumanPropertyName.Middle: Middle += add; break;
            case HumanPropertyName.Leg: Leg += add; break;
        }
    }
}

public enum HumanPropertyName
{
    Arm,
    Middle,
    Leg
}
