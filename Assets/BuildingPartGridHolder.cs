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

    public void AddBuildingPart(Transform buildingPart)
    {
        buildingPartGrid.AddBuildingPart(buildingPart);
    }

    public void AddRuinCell(GameObject ruinCell)
    {
        buildingPartGrid.AddRuinCell(ruinCell);
    }
}
