using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : MonoBehaviour
{
    public static int myStaticData;

    private int myPrefData;
    private SaveData myJsonData = new SaveData();

    private const string JSON_FILE_NAME = "/JsonData.json";
    // Start is called before the first frame update
    void Start()
    {
        myStaticData = 10;
        myPrefData = 20;
        myJsonData.health = 20;
        // SceneManager.LoadScene("Episode 16");
    }

    public void SavePrefData()
    {
        PlayerPrefs.SetInt("PrefData", myPrefData);
    }

    public void LoadPrefData()
    {
        myPrefData = PlayerPrefs.GetInt("PrefData");
        Debug.Log(myPrefData);
    }

    public void SaveJsonData()
    {
        string data = JsonUtility.ToJson(myJsonData);
        string filePath = Application.persistentDataPath + JSON_FILE_NAME;
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath,data);
        Debug.Log("Save Created");
    }

    public void LoadJsonData()
    {
        string filePath = Application.persistentDataPath + JSON_FILE_NAME;
        string data = System.IO.File.ReadAllText(filePath);
        myJsonData = JsonUtility.FromJson<SaveData>(data);
        Debug.Log(myJsonData.health);
    }
}

[System.Serializable]
public class SaveData
{
    public int health;
}