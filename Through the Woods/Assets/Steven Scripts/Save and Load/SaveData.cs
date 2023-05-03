using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int levelCleared;
    public float volumeLevel;

    public SaveData(int _levelCleared, float _volumelevel)
    {
        _levelCleared = levelCleared;
        _volumelevel = volumeLevel;
    }

    
}
