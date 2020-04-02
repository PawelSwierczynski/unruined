using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPartGridHolder : MonoBehaviour
{
    private BuildingPartGrid buildingPartGrid;

    void Start()
    {
        buildingPartGrid = new BuildingPartGrid();
    }

    public bool IsCellFree(Coordinates coordinates)
    {
        return buildingPartGrid.IsCellFree(coordinates);
    }

    public void AddCell(Coordinates coordinates, Transform cell)
    {
        buildingPartGrid.AddCell(coordinates, cell);
    }
}
