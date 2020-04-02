using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildingParts : MonoBehaviour
{
    public GameObject[] buildingParts;
    public GameObject ruinCell;
    void Start()
    {
        //SpawnNewBuildingPart();
    }

    public void SpawnNewBuildingPart(int blockID)
    {        
        Instantiate(buildingParts[blockID], transform.position, Quaternion.identity);
    }

    public void SpawnNewBuildingPart()
    {
        Instantiate(buildingParts[Random.Range(0, buildingParts.Length)], transform.position, Quaternion.identity);        
    }

    public void SpawnRuins()
    {
        List<Coordinates> ruinCellsCoordinates = FindObjectOfType<LevelInformations>().RuinCells;

        foreach (var ruinCellCoordinates in ruinCellsCoordinates)
        {
            GameObject newRuinCell = Instantiate(ruinCell, new Vector3(ruinCellCoordinates.X, ruinCellCoordinates.Y, 0), Quaternion.identity);
            FindObjectOfType<BuildingPartGridHolder>().AddRuinCell(newRuinCell);
        }
    }
}
