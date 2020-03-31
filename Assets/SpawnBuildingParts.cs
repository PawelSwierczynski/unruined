using UnityEngine;

public class SpawnBuildingParts : MonoBehaviour
{
    public GameObject[] buildingParts;

    void Start()
    {
        SpawnNewBuildingPart();
    }

    private void SpawnNewBuildingPart()
    {
        Instantiate(buildingParts[Random.Range(0, buildingParts.Length)], transform.position, Quaternion.identity);
    }
}
