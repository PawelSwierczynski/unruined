using System.Collections.Generic;
using UnityEngine;

public class BuildingPartGrid
{
    private readonly Dictionary<Coordinates, Transform> buildingPartGrid;

    public BuildingPartGrid()
    {
        buildingPartGrid = new Dictionary<Coordinates, Transform>();
    }

    public bool IsCellFree(Coordinates coordinates)
    {
        return !buildingPartGrid.ContainsKey(coordinates);
    }

    private void AddCell(Coordinates coordinates, Transform cell)
    {
        buildingPartGrid.Add(coordinates, cell);
    }

    public void AddBuildingPart(Transform buildingPart)
    {
        foreach (Transform cell in buildingPart)
        {
            Coordinates coordinates = new Coordinates(Mathf.RoundToInt(cell.transform.position.x), Mathf.RoundToInt(cell.transform.position.y));
            AddCell(coordinates, cell);
        }
    }

    public void AddRuinCell(GameObject ruinCell)
    {
        Coordinates coordinates = new Coordinates(Mathf.RoundToInt(ruinCell.transform.position.x), Mathf.RoundToInt(ruinCell.transform.position.y));
        AddCell(coordinates, ruinCell.transform);
    }
}
