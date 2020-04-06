using System.Collections.Generic;
using System;
using UnityEngine;

namespace LevelLoader
{
    [Serializable]
    public sealed class LevelsDictionary
    {
        public List<LevelElement> Levels;

        public LevelsDictionary(string json)
        {
            Levels = JsonUtility.FromJson<List<LevelElement>>(json);
        }

        public LevelsDictionary()
        {
            var tupleList = new List<Coordinates>
                {
                    new Coordinates(1,2),
                    new Coordinates(4,5)
                };
            Levels = new List<LevelElement> { new LevelElement(1, "First Level", tupleList, tupleList) };
        }
    }
}
