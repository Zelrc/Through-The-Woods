using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sounds[] soundArray;
    protected override  void Awake()
    {
        base.Awake();
        foreach(Sounds s in soundArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = MainMenu.volumeLevel;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(soundArray, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogError("This file poof");
        }
        s.source.Play();
    }

    public void StopPlaying(string name)
    {
        Sounds s = Array.Find(soundArray, sound => sound.name == name);

        if(s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void ChangeVolume()
    {
        foreach (Sounds s in soundArray)
        {
            s.source.volume = MainMenu.volumeLevel;
        }
    }
}
