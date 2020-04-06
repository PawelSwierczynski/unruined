using System.Linq;
using System;
using UnityEngine;

namespace GameSaving
{
    [Serializable]
    public sealed class SaveGameSystem
    {
        public SaveGame saveGame;

        public SaveGameSystem(string saveGameJSON)
        {
            saveGame = JsonUtility.FromJson<SaveGame>(saveGameJSON);
        }

        public SaveGameSystem(SaveGame saveGame)
        {
            this.saveGame = saveGame;
        }

        public string RetrieveSaveGame()
        {
            Debug.Log(JsonUtility.ToJson(saveGame, true));

            return JsonUtility.ToJson(saveGame, true);
        }

        public void ResetProgress()
        {
            saveGame.SoundVolume = 1.0f;

            foreach (var levelScore in saveGame.LevelScores)
            {
                levelScore.Score = 0;
            }
        }

        public void SetLevelAsCompleted(int levelIdentifier, int score)
        {
            foreach (var levelScore in saveGame.LevelScores)
            {
                if (levelScore.Identifier == levelIdentifier)
                {
                    levelScore.Score = score;
                }
            }
        }

        public int RetrieveHighscore(int levelIdentifier)
        {
            return (from level in saveGame.LevelScores
                    where level.Identifier == levelIdentifier
                    select level.Score).FirstOrDefault();
        }

        public float GetSoundVolume()
        {
            return saveGame.SoundVolume;
        }

        public void SetSoundVolume(float value)
        {
            saveGame.SoundVolume = value;
        } 
    }
}
