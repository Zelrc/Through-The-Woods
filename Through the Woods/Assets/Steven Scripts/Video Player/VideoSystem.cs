using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSystem : MonoBehaviour
{
    public VideoPlayer tv;
    public VideoClip[] cg;
    Queue<VideoClip> CG = new Queue<VideoClip>();

    private void Start()
    {
        foreach (VideoClip cutscene in cg)
        {
            CG.Enqueue(cutscene);
        }
    }
    public void PlayNextCG()
    {
        Debug.Log("Change clip");
        tv.clip = CG.Dequeue();
        tv.Play();
    }
}
