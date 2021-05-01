using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.IO;

public class HumanPropertyManager : MonoBehaviour
{
    public HumanProperty Property { get { return property; } set { SaveData(); property = value;} }
    private HumanProperty property;
    private DateTime lastUpdate;
    private DateTime startTime;

    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i + 1 <= (DateTime.Today - lastUpdate.Date).TotalDays; i++)
        {
            Degrade();
        }
        lastUpdate = DateTime.Now;

        if((lastUpdate - startTime).TotalDays > 60)
        {
            GoResult();
        }
    }

    private void SaveData()
    {
        var path = Path.Combine(Application.persistentDataPath, UseDataId.id + ".data");
        var content = "0," + startTime + "," + property.ToString();
        File.WriteAllText(path, content);
    }

    private void LoadData()
    {
        var path = Path.Combine(Application.persistentDataPath, UseDataId.id + ".data");
        var content = File.ReadAllText(path).Split(',');
        if(content[0] != "0")
        {
            Debug.LogError("êlÇÃî\óÕÇ∂Ç·Ç»Ç¢ÅI");
            return;
        }

        property = new HumanProperty(UseDataId.id);
        startTime = DateTime.Parse(content[1]);
        property.AddProperty(HumanPropertyName.Arm, float.Parse(content[2]));
        property.AddProperty(HumanPropertyName.Middle, float.Parse(content[3]));
        property.AddProperty(HumanPropertyName.Leg, float.Parse(content[4]));
    }

    private void Degrade()
    {
        property.AddProperty(HumanPropertyName.Arm, -5);
        property.AddProperty(HumanPropertyName.Middle, -5);
        property.AddProperty(HumanPropertyName.Leg, -5);
    }

    private void GoResult()
    {
        SaveData();
        SceneManager.LoadScene("HumanResult");
    }
}
