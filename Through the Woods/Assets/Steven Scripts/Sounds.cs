using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class Sounds
{
    public string name;

    public AudioClip clip;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
