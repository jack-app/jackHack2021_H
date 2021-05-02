using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HumanPropertyManager))]
public class HumanPropertyMangerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Next day"))
        {
            ((HumanPropertyManager)target).SendMessage("NextDay", null, SendMessageOptions.DontRequireReceiver);
        }
    }
}
