using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevPanel : MonoBehaviour
{
    public GameObject devPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            devPanel.SetActive(!devPanel.activeSelf);
        }
    }

    public void ChangeScene(string name)
    {
        AudioManager.Instance.StopPlaying("BattleBGM");
        bool gotVideo = true;
        if(name == "Stage2_2" || name == "Stage3_2" || name == "Stage3_3" || name == "Stage3_2" || name == "Stage4_1" || name == "Stage4_2" || name == "Stage6_2")
        {
            gotVideo = false;
        }
        if(gotVideo)
        {
            VideoSystem.videoName = name;
            SceneManager.LoadScene("VideoTesting");
        }
        else
        {
            SceneManager.LoadScene(name);
        }
    }
}
