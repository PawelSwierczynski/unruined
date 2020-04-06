using System;

namespace GameSaving
{
    [Serializable]
    public sealed class LevelScore
    {
        public int Identifier;
        public int Score;

        public LevelScore(int identifier, int score)
        {
            Identifier = identifier;
            Score = score;
        }
    }
}
