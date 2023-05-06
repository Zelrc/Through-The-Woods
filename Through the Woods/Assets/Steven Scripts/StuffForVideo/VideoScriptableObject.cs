using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoSO", menuName = "ScriptableObjects/VideoSO")]
public class VideoScriptableObject : ScriptableObject
{
    [SerializeField] VideoClip newGame;
    [SerializeField] VideoClip L1M1;
    [SerializeField] VideoClip L1M2;
    [SerializeField] VideoClip L1M3;

    [SerializeField] VideoClip L2M1;
    [SerializeField] VideoClip L2M3;

    [SerializeField] VideoClip L3M1;
    [SerializeField] VideoClip L3M4;

    [SerializeField] VideoClip L4M3;
    [SerializeField] VideoClip L4M4;

    [SerializeField] VideoClip L5M1;

    [SerializeField] VideoClip L6M1;
    [SerializeField] VideoClip L6M3;
    [SerializeField] VideoClip L6M4;

    public VideoClip GetVideo(string videoName)
    {
        switch(videoName)
        {
            case "Map_StageSelect":
                return newGame;
            case "Stage1_First":
                return L1M1;
            case "Stage1_Second":
                return L1M2;
            case "Stage1_Third":
                return L1M3;
            case "Stage2_1":
                return L2M1;
            case "Stage2_3":
                return L2M3;
            case "Stage3_1":
                return L3M1;
            case "Stage3_4":
                return L3M4;
            case "Stage4_3":
                return L4M3;
            case "Stage4_4":
                return L4M4;
            case "Stage5_1":
                return L5M1;
            case "Stage6_1":
                return L6M1;
            case "Stage6_3":
                return L6M3;
            case "Ending":
                return L6M4;
            default:
                return L1M1;
        }
    }
}
