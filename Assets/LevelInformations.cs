using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LevelLoader;

public class LevelInformations : MonoBehaviour
{
    public int LevelIdentifier { get; private set; }
    public string LevelName { get; private set; }
    public int LeftBorderPositionX { get; private set; }
    public int RightBorderPositionY { get; private set; }
    public int DownBorderPositionY { get; private set; }
    public List<Coordinates> patternCells { get; private set; }
    public List<Coordinates> rainCells { get; private set; }

    void Start()
    {
        LeftBorderPositionX = 0;
        RightBorderPositionY = 22;
        DownBorderPositionY = 40;

        LevelsDictionary levelsDictionary = new LevelsDictionary(File.ReadAllText("Assets/Resources/Levels/Levels.json"));

    }
}
