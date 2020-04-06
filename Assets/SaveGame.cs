using System;
using System.Collections.Generic;

namespace GameSaving
{
    [Serializable]
    public sealed class SaveGame
    {
        public float SoundVolume;
        public List<LevelScore> LevelScores;

        public SaveGame(List<LevelScore> levelScores)
        {
            SoundVolume = 1.0f;
            LevelScores = levelScores;
        }
    }
}
