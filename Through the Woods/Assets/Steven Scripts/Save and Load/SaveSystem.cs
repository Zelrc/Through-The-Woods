using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(int levelCleared, float volumeLevel)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ThroughTheWoods.fyp";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(levelCleared, volumeLevel);
        Debug.LogError(volumeLevel);
        Debug.Log(data.volumeLevel);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/ThroughTheWoods.fyp";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.LogWarning(data.volumeLevel);

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            Save(0, 1f);
            return LoadData();
        }
    }
}
