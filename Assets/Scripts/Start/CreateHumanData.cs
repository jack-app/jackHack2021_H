using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        var id = Guid.NewGuid().ToString();
        var path = Path.Combine(Application.persistentDataPath, id + ".data");
        var content = "0," + DateTime.Now.ToString() + ",60,60,60";
        File.WriteAllText(path, content, System.Text.Encoding.UTF8);
        UseDataId.id = id;
        SceneManager.LoadScene(SceneName.HumanMain.ToString());
    }
}
