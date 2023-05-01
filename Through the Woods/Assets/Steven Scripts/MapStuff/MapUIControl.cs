using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MapUIControl : MonoBehaviour
{
    [SerializeField] GameObject CloudGroup1;
    [SerializeField] GameObject CloudGroup2;
    [SerializeField] GameObject CloudGroup3;

    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;

    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] Button button6;

    private void Awake()
    {
        button1.onClick.RemoveListener(() => GoToScene("Stage1_First"));
        button1.onClick.AddListener(() => GoToScene("Stage1_First"));
        button2.onClick.RemoveListener(() => GoToScene("Stage1_Second"));
        button2.onClick.AddListener(() => GoToScene("Stage1_Second"));
        button3.onClick.RemoveListener(() => GoToScene("Stage1_Third"));
        button3.onClick.AddListener(() => GoToScene("Stage1_Third"));
        button4.onClick.RemoveListener(() => GoToScene("Stage2_1"));
        button4.onClick.AddListener(() => GoToScene("Stage2_1"));
        button5.onClick.RemoveListener(() => GoToScene("Stage2_2"));
        button5.onClick.AddListener(() => GoToScene("Stage2_2"));
        button6.onClick.RemoveListener(() => GoToScene("Stage2_3"));
        button6.onClick.AddListener(() => GoToScene("Stage2_3"));
    }
   
    void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
