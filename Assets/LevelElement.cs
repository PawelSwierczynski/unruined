using System;
using System.Collections.Generic;

namespace LevelLoader
{
    [Serializable]
    public sealed class LevelElement
    {
        public int LevelID;
        public string Name;
        public List<Coordinates> ExistingBlocks;
        public List<Coordinates> EmptyBlocks;

        public LevelElement(int levelID, string name, List<Coordinates> existingBlocks, List<Coordinates> emptyBlocks)
        {
            LevelID = levelID;
            Name = name;
            ExistingBlocks = existingBlocks;
            EmptyBlocks = emptyBlocks;
        }
    }
}
