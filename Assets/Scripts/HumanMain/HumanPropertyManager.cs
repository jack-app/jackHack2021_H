using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// �l�Ԃ̔\�͒l���ė��B
/// </summary>
public class HumanPropertyManager : MonoBehaviour
{
    /// <summary>
    /// �l�Ԃ̔\�͒l�B
    /// </summary>
    public HumanProperty Property { get { return property; } set { SaveData(); property = value;} }
    private HumanProperty property;

    /// <summary>
    /// �N�I�[�^�[���I��������B
    /// </summary>
    public bool isFinished { get { return (lastUpdate - startTime).TotalDays > 60; } }
    private DateTime lastUpdate;
    private DateTime startTime;

    void Start()
    {
        LoadData();
    }

    void Update()
    {
        // ���t���m�F���ē��𒴂������\�̓_�E���B
        for(var i = 0; i + 1 <= (DateTime.Today - lastUpdate.Date).TotalDays; i++)
        {
            Degrade();
        }
        lastUpdate = DateTime.Now;
    }

    /// <summary>
    /// �f�[�^��ۑ��B
    /// </summary>
    private void SaveData()
    {
        var path = Path.Combine(Application.persistentDataPath, UseDataId.id + ".data");
        var content = "0," + startTime + "," + property.ToString();
        File.WriteAllText(path, content);
    }

    /// <summary>
    /// �f�[�^�̓ǂݍ��݁B
    /// </summary>
    private void LoadData()
    {
        var path = Path.Combine(Application.persistentDataPath, UseDataId.id + ".data");
        var content = File.ReadAllText(path).Split(',');
        if(content[0] != "0")
        {
            Debug.LogError("�l�̔\�͂���Ȃ��I");
            return;
        }

        property = new HumanProperty(UseDataId.id);
        startTime = DateTime.Parse(content[1]);
        property.AddProperty(HumanPropertyName.Arm, float.Parse(content[2]));
        property.AddProperty(HumanPropertyName.Middle, float.Parse(content[3]));
        property.AddProperty(HumanPropertyName.Leg, float.Parse(content[4]));
    }

    /// <summary>
    /// �\��1�����_�E���B
    /// </summary>
    private void Degrade()
    {
        property.AddProperty(HumanPropertyName.Arm, -5);
        property.AddProperty(HumanPropertyName.Middle, -5);
        property.AddProperty(HumanPropertyName.Leg, -5);
    }

    /// <summary>
    /// ���U���g��ʂցB
    /// </summary>
    private void GoResult()
    {
        SaveData();
        SceneManager.LoadScene("HumanResult");
    }
}
