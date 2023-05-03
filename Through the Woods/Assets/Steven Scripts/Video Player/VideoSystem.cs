using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoSystem : MonoBehaviour
{
    public VideoPlayer tv;
    public VideoScriptableObject videoSO;
    public Button SkipButton;
    public static string videoName;

    private void Awake()
    {
        SkipButton.onClick.RemoveListener(Skip);
        SkipButton.onClick.AddListener(Skip);
    }
    private void Start()
    {
        tv.loopPointReached += GoToScene;
        PlayCG();
    }

    public void PlayCG()
    {
        tv.clip = videoSO.GetVideo(videoName);
        tv.Play();
    }

    void GoToScene(VideoPlayer tv)
    {
        SceneManager.LoadScene(videoName);
    }

    void Skip()
    {
        AudioManager.Instance.Play("UISelectSound");
        tv.time += 1000f;
    }
}
