using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public string timestamp;
    public int health;
    public int currentCoins;
    public int lives;
    public Vector3 position;


    public static void SaveGame(SaveData saveData)
    {
        string filePath = Application.persistentDataPath + "/savefile.sav";

        string jsonString = JsonUtility.ToJson(saveData);

        System.IO.File.WriteAllText(filePath, jsonString);
    }
}
