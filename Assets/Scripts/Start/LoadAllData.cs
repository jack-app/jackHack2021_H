using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データをロードする。
/// </summary>
public class LoadAllData : MonoBehaviour
{
    private List<string> playedId;

    private void OnEnable()
    {
        playedId = new List<string>();
        var list = new List<SavedData>();
        foreach(var file in Directory.GetFiles(Application.persistentDataPath, "*.data"))
        {
            var content = File.ReadAllText(file).Split(',');
            var data = new SavedData();
            if(content[0] == "0")
            {
                data.type = "人間";
            }
            else
            {
                data.type = "ウイルス";
            }
            data.id = Path.GetFileName(file).Replace(".data", "");
            data.start = DateTime.Parse(content[1]);
            list.Add(data);
        }
        list = list.OrderBy(value => value.start).ToList();

        foreach(var content in list)
        {
            playedId.Add(content.id);
        }
    }

    /// <summary>
    /// プレイヤーを選択したときに呼んでね。
    /// </summary>
    /// <param name="index">インデックス。</param>
    public void OnClicked(int index)
    {
        UseDataId.id = playedId[index];
    }
}

public class SavedData
{
    public string type;
    public string id;
    public DateTime start;
}
