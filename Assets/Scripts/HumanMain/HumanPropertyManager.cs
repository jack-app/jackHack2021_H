using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
/// <summary>
/// 人間の能力値を監理。
/// </summary>
public class HumanPropertyManager : MonoBehaviour
{
    /// <summary>
    /// 人間の能力値。
    /// </summary>
    public HumanProperty Property { get { return property; } set { SaveData(); property = value;} }
    private HumanProperty property;

    /// <summary>
    /// クオーターが終わったか。
    /// </summary>
    public bool isFinished { get { return (lastUpdate - startTime).TotalDays > 60; } }
    private DateTime lastUpdate;
    private DateTime startTime;
    public Button ResultBtn;

    void Start()
    {
        LoadData();
    }

    void Update()
    {
        // 日付を確認して日を超えた分能力ダウン。
        for(var i = 0; i + 1 <= (DateTime.Today - lastUpdate.Date).TotalDays; i++)
        {
            Degrade();
        }
        lastUpdate = DateTime.Now;
        ResultBtn.interactable = isFinished;
    }

    /// <summary>
    /// データを保存。
    /// </summary>
    private void SaveData()
    {
        var path = Path.Combine(Application.persistentDataPath, UseDataId.id + ".data");
        var content = "0," + startTime + "," + property.ToString();
        File.WriteAllText(path, content, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// データの読み込み。
    /// </summary>
    private void LoadData()
    {
        var path = Path.Combine(Application.persistentDataPath, UseDataId.id + ".data");
        var content = File.ReadAllText(path, System.Text.Encoding.UTF8).Split(',');
        if(content[0] != "0")
        {
            Debug.LogError("人の能力じゃない！");
            return;
        }

        property = new HumanProperty(UseDataId.id);
        startTime = DateTime.Parse(content[1]);
        property.AddProperty(HumanPropertyName.Arm, float.Parse(content[2]));
        property.AddProperty(HumanPropertyName.Middle, float.Parse(content[3]));
        property.AddProperty(HumanPropertyName.Leg, float.Parse(content[4]));
    }

    /// <summary>
    /// 能力1日分ダウン。
    /// </summary>
    private void Degrade()
    {
        property.AddProperty(HumanPropertyName.Arm, -5);
        property.AddProperty(HumanPropertyName.Middle, -5);
        property.AddProperty(HumanPropertyName.Leg, -5);
    }

    /// <summary>
    /// リザルト画面へ。
    /// </summary>
    private void GoResult()
    {
        SaveData();
        SceneManager.LoadScene("HumanResult");
    }
}
