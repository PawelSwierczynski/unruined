using System.Collections.Generic;
using UnityEngine;

public class BuildingPartPhysics : MonoBehaviour
{
    private MoveValidator moveValidator;
    private static List<Coordinates> patternCoordinates;

    private bool isLeftControlPressed;
    private bool isRightControlPressed;
    private bool isUpControlPressed;
    private bool isMovingDown;
    private float lastMoveDownUpdateTime;
    private BuildingPartGridHolder buildingPartGridHolder;
    public float moveDownTimeDelay = 1.0f;
    public Vector3 rotationPoint;

    void Start()
    {
        moveValidator = FindObjectOfType<MoveValidator>();

        isLeftControlPressed = false;
        isRightControlPressed = false;
        isMovingDown = false;
        lastMoveDownUpdateTime = Time.time;
        buildingPartGridHolder = FindObjectOfType<BuildingPartGridHolder>();

        patternCoordinates = new List<Coordinates>();
        patternCoordinates.AddRange(new List<Coordinates>{
           new Coordinates(8, 0),
           new Coordinates(9, 0),
           new Coordinates(10, 0),
           new Coordinates(11, 0),
           new Coordinates(12, 0),
           new Coordinates(13, 0),
           new Coordinates(8, 1),
           new Coordinates(9, 1),
           new Coordinates(10, 1),
           new Coordinates(11, 1),
           new Coordinates(12, 1),
           new Coordinates(13, 1),
           new Coordinates(8, 2),
           new Coordinates(9, 2),
           new Coordinates(10, 2),
           new Coordinates(11, 2),
           new Coordinates(12, 2),
           new Coordinates(13, 2),
           new Coordinates(8, 3),
           new Coordinates(9, 3),
           new Coordinates(10, 3),
           new Coordinates(11, 3),
           new Coordinates(12, 3),
           new Coordinates(13, 3),
           new Coordinates(8, 4),
           new Coordinates(9, 4),
           new Coordinates(10, 4),
           new Coordinates(11, 4),
           new Coordinates(12, 4),
           new Coordinates(13, 4),
           new Coordinates(6, 5),
           new Coordinates(7, 5),
           new Coordinates(8, 5),
           new Coordinates(9, 5),
           new Coordinates(10, 5),
           new Coordinates(11, 5),
           new Coordinates(12, 5),
           new Coordinates(13, 5),
           new Coordinates(14, 5),
           new Coordinates(15, 5),
           new Coordinates(7, 6),
           new Coordinates(8, 6),
           new Coordinates(9, 6),
           new Coordinates(10, 6),
           new Coordinates(11, 6),
           new Coordinates(12, 6),
           new Coordinates(13, 6),
           new Coordinates(14, 6),
           new Coordinates(8, 7),
           new Coordinates(9, 7),
           new Coordinates(10, 7),
           new Coordinates(11, 7),
           new Coordinates(12, 7),
           new Coordinates(13, 7),
           new Coordinates(9, 8),
           new Coordinates(10, 8),
           new Coordinates(11, 8),
           new Coordinates(12, 8),
           new Coordinates(10, 9),
           new Coordinates(11, 9),
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isLeftControlPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRightControlPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isUpControlPressed = true;
        }

        if (Time.time - lastMoveDownUpdateTime >= (Input.GetKey(KeyCode.DownArrow) ? moveDownTimeDelay / 10 : moveDownTimeDelay))
        {
            isMovingDown = true;
            lastMoveDownUpdateTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        if (isLeftControlPressed)
        {
            transform.position += new Vector3(-1, 0, 0);

            if (!moveValidator.IsMoveValid(transform))
            {
                transform.position += new Vector3(1, 0, 0);
            }

            isLeftControlPressed = false;
        }

        if (isRightControlPressed)
        {
            transform.position += new Vector3(1, 0, 0);

            if (!moveValidator.IsMoveValid(transform))
            {
                transform.position += new Vector3(-1, 0, 0);
            }

            isRightControlPressed = false;
        }
        
        if (isUpControlPressed)
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);

            if (!moveValidator.IsMoveValid(transform))
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }

            isUpControlPressed = false;
        }

        if (isMovingDown)
        {
            transform.position += new Vector3(0, -1, 0);

            if (!moveValidator.IsMoveValid(transform))
            {
                transform.position += new Vector3(0, 1, 0);
                buildingPartGridHolder.AddBuildingPart(transform);

                if (IsLevelCompleted())
                {
                    Debug.Log("You've completed the level!");
                }

                enabled = false;

                FindObjectOfType<SpawnBuildingParts>().SpawnNewBuildingPart();
            }

            isMovingDown = false;
        }
    }

    private bool IsLevelCompleted()
    {
        foreach (var patternElementCoordinates in patternCoordinates)
        {
            if (buildingPartGridHolder.IsCellFree(patternElementCoordinates))
            {
                return false;
            }
        }

        return true;
    }
}
