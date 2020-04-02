using UnityEngine;

public class MoveValidator : MonoBehaviour
{
    private BuildingPartGridHolder buildingPartGridHolder;
    private LevelInformations levelInformations;

    void Start()
    {
        buildingPartGridHolder = FindObjectOfType<BuildingPartGridHolder>();
        levelInformations = FindObjectOfType<LevelInformations>();
    }

    public bool IsMoveValid(Transform buildingPart)
    {
        foreach (Transform cell in buildingPart)
        {
            Coordinates coordinates = new Coordinates(Mathf.RoundToInt(cell.transform.position.x), Mathf.RoundToInt(cell.transform.position.y));

            if (coordinates.X < levelInformations.LeftBorderPositionX || coordinates.X >= levelInformations.RightBorderPositionY || coordinates.Y >= levelInformations.DownBorderPositionY || coordinates.Y < 0)
            {
                return false;
            }

            if (!buildingPartGridHolder.IsCellFree(coordinates))
            {
                return false;
            }
        }

        return true;
    }
}
