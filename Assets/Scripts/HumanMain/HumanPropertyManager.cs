using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using Deform;

/// <summary>
/// 人間の能力値を監理。
/// </summary>
public class HumanPropertyManager : MonoBehaviour
{
    /// <summary>
    /// 人間の能力値。
    /// </summary>
    public HumanProperty Property { get { return property; } set { SaveData(); ApplyMussle(); property = value;} }
    private HumanProperty property;

    /// <summary>
    /// クオーターが終わったか。
    /// </summary>
    public bool isFinished { get { return (lastUpdate - startTime).TotalDays > 60; } }
    private DateTime lastUpdate;
    private DateTime startTime;
    public Button ResultBtn;

    [SerializeField]
    private List<SpherifyDeformer> armsUp;

    [SerializeField]
    private List<SquashAndStretchDeformer> armsDown;

    [SerializeField]
    private List<SpherifyDeformer> middlesUp;

    [SerializeField]
    private List<SquashAndStretchDeformer> middlesDown;

    [SerializeField]
    private List<SpherifyDeformer> legsUp;

    [SerializeField]
    private List<SquashAndStretchDeformer> legsDown;

    void Start()
    {
        LoadData();
    }

    void Update()
    {
        if (property != null && lastUpdate != default)
        {
            // 日付を確認して日を超えた分能力ダウン。
            for (var i = 0; i + 1 <= (DateTime.Today - lastUpdate.Date).TotalDays; i++)
            {
                Degrade();
            }
            ResultBtn.interactable = isFinished;
        }
        lastUpdate = DateTime.Now;
    }

    private void ApplyMussle()
    {
        if (Property.Arm < 60)
        {
            foreach (var arm in armsDown)
            {
                arm.Factor = (60 - Property.Arm) / 60f;
            }
            foreach (var arm in armsUp)
            {
                arm.Factor = 0;
            }
        }
        else
        {
            foreach (var arm in armsUp)
            {
                arm.Factor = (Property.Arm - 60) / 40f;
            }
            foreach (var arm in armsDown)
            {
                arm.Factor = 0;
            }
        }

        if (Property.Middle < 60f)
        {
            foreach (var middle in middlesDown)
            {
                middle.Factor = (60 - Property.Middle) / 60f;
            }
            foreach (var middle in middlesUp)
            {
                middle.Factor = 0;
            }
        }
        else
        {
            foreach (var middle in middlesUp)
            {
                middle.Factor = (Property.Middle - 60) / 40;
            }
            foreach (var middle in middlesDown)
            {
                middle.Factor = 0;
            }
        }

        if (Property.Leg < 60)
        {
            foreach (var leg in legsDown)
            {
                leg.Factor = (60 - Property.Leg) / 60f;
            }
            foreach (var leg in legsUp)
            {
                leg.Factor = 0;
            }
        }
        else
        {
            foreach (var leg in legsUp)
            {
                leg.Factor = (Property.Leg - 60) / 40;
            }
            foreach (var leg in legsDown)
            {
                leg.Curvature = 0;
            }
        }
    }

    /// <summary>
    /// データを保存。
    /// </summary>
    private void SaveData()
    {
        var path = Path.Combine(Application.persistentDataPath, UseDataId.id + ".data");
        var content = "0," + startTime + "," + property.Arm.ToString() + "," + property.Middle.ToString() + "," + property.Leg.ToString();
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
        Property = property;
    }

    /// <summary>
    /// 能力1日分ダウン。
    /// </summary>
    private void Degrade()
    {
        property.AddProperty(HumanPropertyName.Arm, -5);
        property.AddProperty(HumanPropertyName.Middle, -5);
        property.AddProperty(HumanPropertyName.Leg, -5);
        Property = property;
    }

    /// <summary>
    /// リザルト画面へ。
    /// </summary>
    public void GoResult()
    {
        SaveData();
        SceneManager.LoadScene(SceneName.HumanResult.ToString());
    }

    public void NextDay()
    {
        startTime = startTime.AddDays(-1);
        Degrade();
        Debug.LogWarning("世界が改変されました。");
    }
}
