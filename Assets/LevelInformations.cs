using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using LevelLoader;

public class LevelInformations : MonoBehaviour
{
    public int LevelIdentifier { get; private set; }
    public string LevelName { get; private set; }
    public int LeftBorderPositionX { get; private set; }
    public int RightBorderPositionY { get; private set; }
    public int DownBorderPositionY { get; private set; }
    public List<Coordinates> PatternCells { get; private set; }
    public List<Coordinates> RuinCells { get; private set; }

    void Start()
    {
        LeftBorderPositionX = 0;
        RightBorderPositionY = 22;
        DownBorderPositionY = 40;

        LevelsDictionary levelsDictionary = new LevelsDictionary(File.ReadAllText("Assets/Resources/Levels/Levels.json"));
        LevelElement loadedLevel = (from level in levelsDictionary.Levels
                                    where level.LevelID == GameManager.Instance.SelectedLevel
                                    select level).FirstOrDefault();

        LevelIdentifier = loadedLevel.LevelID;
        LevelName = loadedLevel.Name;
        PatternCells = loadedLevel.EmptyBlocks;
        RuinCells = loadedLevel.ExistingBlocks;

        FindObjectOfType<LoadBackgroundToFill>().LoadBackground(LevelIdentifier);
        FindObjectOfType<SpawnBuildingParts>().SpawnRuins();
    }

    public void ChangeCellsColors(GameObject buildingPart)
    {
        int counter = 0;
        var renderers = buildingPart.GetComponentsInChildren<SpriteRenderer>();

        foreach (Transform cell in buildingPart.transform)
        {
            Coordinates coordinates = new Coordinates(Mathf.RoundToInt(cell.transform.position.x), Mathf.RoundToInt(cell.transform.position.y));

            if (PatternCells.Contains(coordinates))
            {
                renderers[counter].color = new Color32(147, 132, 132, 255);
            }
            else
            {
                renderers[counter].color = Color.red;
            }

            counter++;
        }
    } 
}
