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
        button1.onClick.RemoveListener(Level1);
        button1.onClick.AddListener(Level1);
        button2.onClick.RemoveListener(Level2);
        button2.onClick.AddListener(Level2);
        button3.onClick.RemoveListener(Level3);
        button3.onClick.AddListener(Level3);
        button4.onClick.RemoveListener(Level4);
        button4.onClick.AddListener(Level4);
        button5.onClick.RemoveListener(Level5);
        button5.onClick.AddListener(Level5);
        button6.onClick.RemoveListener(Level6);
        button6.onClick.AddListener(Level6);
    }
   
    void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Level1()
    {
        VideoSystem.videoName = "Stage1_First";
        SceneManager.LoadScene("VideoTesting");
    }

    void Level2()
    {
        VideoSystem.videoName = "Stage2_1";
        SceneManager.LoadScene("VideoTesting");
    }

    void Level3()
    {
        VideoSystem.videoName = "Stage3_1";
        SceneManager.LoadScene("VideoTesting");
    }

    void Level4()
    {
        SceneManager.LoadScene("Stage4_1");
    }

    void Level5()
    {
        VideoSystem.videoName = "Stage5_1";
        SceneManager.LoadScene("VideoTesting");
    }

    void Level6()
    {
        VideoSystem.videoName = "Stage6_1";
        SceneManager.LoadScene("VideoTesting");
    }
}
