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

    [SerializeField] Button backButton;

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
        backButton.onClick.RemoveListener(GoBackMainMenu);
        backButton.onClick.AddListener(GoBackMainMenu);

        if (MainMenu.levelCleared < 1)
        {
            button2.interactable = false;
        }

        if (MainMenu.levelCleared < 2)
        {
            button3.interactable = false;
        }

        if (MainMenu.levelCleared < 3)
        {
            button4.interactable = false;
        }

        if (MainMenu.levelCleared < 4)
        {
            
            button5.interactable = false;
        }

        if (MainMenu.levelCleared < 5)
        {
            button6.interactable = false;
        }

        if(MainMenu.levelCleared > 3)
        {
            CloudGroup1.SetActive(false);
        }
    }

    private void Start()
    {
        AudioManager.Instance.Play("MapChosing");
    }
    void Level1()
    {
        AudioManager.Instance.Play("UISelectSound");
        AudioManager.Instance.StopPlaying("MapChosing");
        VideoSystem.videoName = "Stage1_First";
        SceneManager.LoadScene("VideoTesting");
    }

    void Level2()
    {
        AudioManager.Instance.Play("UISelectSound");
        AudioManager.Instance.StopPlaying("MapChosing");
        VideoSystem.videoName = "Stage2_1";
        SceneManager.LoadScene("VideoTesting");
    }

    void Level3()
    {
        AudioManager.Instance.Play("UISelectSound");
        AudioManager.Instance.StopPlaying("MapChosing");
        VideoSystem.videoName = "Stage3_1";
        SceneManager.LoadScene("VideoTesting");
    }

    void Level4()
    {
        AudioManager.Instance.Play("UISelectSound");
        AudioManager.Instance.StopPlaying("MapChosing");
        SceneManager.LoadScene("Stage4_1");
    }

    void Level5()
    {
        AudioManager.Instance.Play("UISelectSound");
        AudioManager.Instance.StopPlaying("MapChosing");
        VideoSystem.videoName = "Stage5_1";
        SceneManager.LoadScene("VideoTesting");
    }

    void Level6()
    {
        AudioManager.Instance.Play("UISelectSound");
        AudioManager.Instance.StopPlaying("MapChosing");
        VideoSystem.videoName = "Stage6_1";
        SceneManager.LoadScene("VideoTesting");
    }

    void GoBackMainMenu()
    {
        AudioManager.Instance.Play("UISelectSound");
        AudioManager.Instance.StopPlaying("MapChosing");
        SceneManager.LoadScene("Main Menu");
    }
}
