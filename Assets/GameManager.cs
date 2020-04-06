using System.IO;
using UnityEngine;
using GameSaving;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int SelectedLevel { get; set; }
    public SaveGameSystem SaveGameSystem { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SaveGameSystem = new SaveGameSystem(File.ReadAllText(Application.streamingAssetsPath + "/GameSave.json"));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        File.WriteAllText(Application.streamingAssetsPath + "/GameSave.json", SaveGameSystem.RetrieveSaveGame());
    }

    public void SaveSettings()
    {
        SaveGameSystem.SetSoundVolume(SoundManager.Instance.SoundVolume);

        Debug.Log(SoundManager.Instance.SoundVolume);

        SaveGame();
    }
}
