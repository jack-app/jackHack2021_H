using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// クリックしてシーンを変えるクラス。
/// </summary>
public class ClickedSceneChanger : MonoBehaviour
{
    /// <value="nextSceneName">次のシーンの名前 </summary>
    [SerializeField]
    private SceneName nextSceneName;

    /// <value="deleteData">次のシーンの名前 </summary>
    [SerializeField]
    private bool deleteData;

    /// <summary>
    /// クリックしたときのイベントに登録してね。
    /// </summary>
    public void OnClicked()
    {
        if (deleteData)
        {
            File.Delete(Path.Combine(Application.persistentDataPath, UseDataId.id + ".data"));
            UseDataId.id = "";
        }
        SceneManager.LoadScene(nextSceneName.ToString());
    }
}
