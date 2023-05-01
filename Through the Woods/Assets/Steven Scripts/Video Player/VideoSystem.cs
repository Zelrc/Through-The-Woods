using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSystem : MonoBehaviour
{
    public VideoPlayer tv;
    public VideoScriptableObject videoSO;

    public static string videoName;

    private void Start()
    {
            tv.loopPointReached += GoToScene;
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
}
