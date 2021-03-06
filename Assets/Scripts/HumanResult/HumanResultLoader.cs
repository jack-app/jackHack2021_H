using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 結果をロードする。
/// </summary>
public class HumanResultLoader : MonoBehaviour
{
    [SerializeField]
    private Text grade;

    [SerializeField]
    private RawImage gradeBack;

    [SerializeField]
    private Text comment;

    [SerializeField]
    private string sComment;

    [SerializeField]
    private string aComment;

    [SerializeField]
    private string bComment;

    [SerializeField]
    private string cComment;

    [SerializeField]
    private string fComment;


    [SerializeField]
    private void Start()
    {
        var content = File.ReadAllText(Path.Combine(Application.persistentDataPath, UseDataId.id + ".data")).Split(',');
        var sum = 0.0f;
        for (var i = 2; i < 5; i++)
        {
            sum += float.Parse(content[i]);
        }

        if(sum >= 95 * 3)
        {
            grade.text = "S";
            gradeBack.color = Color.yellow;
            comment.text = sComment;
        }
        else if(sum >= 80 * 3)
        {
            grade.text = "A";
            gradeBack.color = new Color(0.7f, 0.7f, 0.7f);
            comment.text = aComment;
        }
        else if(sum >= 70 * 3)
        {
            grade.text = "B";
            gradeBack.color = new Color(0.7f, 0.7f, 0.7f);
            comment.text = bComment;
        }
        else if(sum >= 60 * 3)
        {
            grade.text = "C";
            gradeBack.color = new Color(0.764151f, 0.3340157f, 0.118948f);
            comment.text = cComment;
        }
        else
        {
            grade.text = "F";
            gradeBack.color = Color.clear;
            comment.text = fComment;
        }
    }
}
