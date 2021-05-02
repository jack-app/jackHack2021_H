using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �N���b�N���ăV�[����ς���N���X�B
/// </summary>
public class ClickedSceneChanger : MonoBehaviour
{
    /// <value="nextSceneName">���̃V�[���̖��O </summary>
    [SerializeField]
    private SceneName nextSceneName;

    /// <value="deleteData">���̃V�[���̖��O </summary>
    [SerializeField]
    private bool deleteData;

    /// <summary>
    /// �N���b�N�����Ƃ��̃C�x���g�ɓo�^���ĂˁB
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
