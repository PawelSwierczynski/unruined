using System.IO;
using UnityEngine;
using GameSaving;

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

            SaveGameSystem = new SaveGameSystem(File.ReadAllText("Assets/Resources/Saves/GameSave.json"));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        File.WriteAllText("Assets/Resources/Saves/GameSave.json", SaveGameSystem.RetrieveSaveGame());
    }
}
