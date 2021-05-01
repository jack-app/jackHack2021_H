using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickedSceneChanger : MonoBehaviour
{
    [SerializeField]
    private SceneName nextScenename;
    
    public void OnClicked()
    {
        SceneManager.LoadScene(nextScenename.ToString());
    }
}
