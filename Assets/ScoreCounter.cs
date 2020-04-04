using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int CurrentScore { get; set; }
    public int HighScore { get; set; }

    private BuildingPartGrid buildingPartGrid;
    private LevelInformations levelInformations;

    void Start()
    {
        CurrentScore = 0;
        HighScore = GameManager.Instance.SaveGameSystem.RetrieveHighscore(GameManager.Instance.SelectedLevel);

        buildingPartGrid = FindObjectOfType<BuildingPartGridHolder>().RetrieveBuildingPartGrid();
        levelInformations = FindObjectOfType<LevelInformations>();
    }

    public void CalculateScore()
    {
        int currentScore = 0;

        foreach (var patternCell in levelInformations.PatternCells)
        {
            if (!buildingPartGrid.IsCellFree(patternCell))
            {
                currentScore++;
            }
        }

        currentScore -= (buildingPartGrid.RetrieveNumberOfCells() - levelInformations.RuinCells.Count - currentScore);

        CurrentScore = (int)((double)currentScore / levelInformations.PatternCells.Count * 100.0);

        FindObjectOfType<LevelCompletion>().SetCompletion(CurrentScore);

        if (HighScore < CurrentScore)
        {
            HighScore = CurrentScore;
        }
    }

    public bool IsGameWon()
    {
        int currentScore = 0;

        foreach (var patternCell in levelInformations.PatternCells)
        {
            if (!buildingPartGrid.IsCellFree(patternCell))
            {
                currentScore++;
            }
        }

        return (double)currentScore / levelInformations.PatternCells.Count * 100.0 >= 80.0f;
    }
}
