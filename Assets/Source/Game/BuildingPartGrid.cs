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

    public void AddCell(Coordinates coordinates, Transform cell)
    {
        buildingPartGrid.Add(coordinates, cell);
    }
}