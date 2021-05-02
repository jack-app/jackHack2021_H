using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人間の初期データを作成するクラス。
/// </summary>
public class CreateHumanData : MonoBehaviour
{
    /// <summary>
    /// クリックしたときのイベントに登録してね。
    /// </summary>
    public void OnClicked()
    {
        var path = Path.Combine(Application.persistentDataPath, Guid.NewGuid().ToString() + ".data");
        var content = "0," + DateTime.Now.ToString() + ",60,60,60";
        File.WriteAllText(path, content, System.Text.Encoding.UTF8);
    }
}
