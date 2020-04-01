using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPartPhysics : MonoBehaviour
{
    private const int LEFT_BORDER_POSITION_X = 0;
    private const int RIGHT_BORDER_POSITION_X = 22;
    private const int DOWN_BORDER_POSITION_Y = 40;

    private static Transform[,] grid = new Transform[RIGHT_BORDER_POSITION_X, DOWN_BORDER_POSITION_Y];
    private static List<Tuple<int, int>> patternCoordinates = new List<Tuple<int, int>>();

    private bool isLeftControlPressed;
    private bool isRightControlPressed;
    private bool isUpControlPressed;
    private bool isMovingDown;
    private float lastMoveDownUpdateTime;
    public float moveDownTimeDelay = 1.0f;
    public Vector3 rotationPoint;

    void Start()
    {
        isLeftControlPressed = false;
        isRightControlPressed = false;
        isMovingDown = false;
        lastMoveDownUpdateTime = Time.time;
        patternCoordinates.AddRange(new List<Tuple<int, int>>{
           new Tuple<int, int> (8, 0),
           new Tuple<int, int> (9, 0),
           new Tuple<int, int> (10, 0),
           new Tuple<int, int> (11, 0),
           new Tuple<int, int> (12, 0),
           new Tuple<int, int> (13, 0),
           new Tuple<int, int> (8, 1),
           new Tuple<int, int> (9, 1),
           new Tuple<int, int> (10, 1),
           new Tuple<int, int> (11, 1),
           new Tuple<int, int> (12, 1),
           new Tuple<int, int> (13, 1),
           new Tuple<int, int> (8, 2),
           new Tuple<int, int> (9, 2),
           new Tuple<int, int> (10, 2),
           new Tuple<int, int> (11, 2),
           new Tuple<int, int> (12, 2),
           new Tuple<int, int> (13, 2),
           new Tuple<int, int> (8, 3),
           new Tuple<int, int> (9, 3),
           new Tuple<int, int> (10, 3),
           new Tuple<int, int> (11, 3),
           new Tuple<int, int> (12, 3),
           new Tuple<int, int> (13, 3),
           new Tuple<int, int> (8, 4),
           new Tuple<int, int> (9, 4),
           new Tuple<int, int> (10, 4),
           new Tuple<int, int> (11, 4),
           new Tuple<int, int> (12, 4),
           new Tuple<int, int> (13, 4),
           new Tuple<int, int> (6, 5),
           new Tuple<int, int> (7, 5),
           new Tuple<int, int> (8, 5),
           new Tuple<int, int> (9, 5),
           new Tuple<int, int> (10, 5),
           new Tuple<int, int> (11, 5),
           new Tuple<int, int> (12, 5),
           new Tuple<int, int> (13, 5),
           new Tuple<int, int> (14, 5),
           new Tuple<int, int> (15, 5),
           new Tuple<int, int> (7, 6),
           new Tuple<int, int> (8, 6),
           new Tuple<int, int> (9, 6),
           new Tuple<int, int> (10, 6),
           new Tuple<int, int> (11, 6),
           new Tuple<int, int> (12, 6),
           new Tuple<int, int> (13, 6),
           new Tuple<int, int> (14, 6),
           new Tuple<int, int> (8, 7),
           new Tuple<int, int> (9, 7),
           new Tuple<int, int> (10, 7),
           new Tuple<int, int> (11, 7),
           new Tuple<int, int> (12, 7),
           new Tuple<int, int> (13, 7),
           new Tuple<int, int> (9, 8),
           new Tuple<int, int> (10, 8),
           new Tuple<int, int> (11, 8),
           new Tuple<int, int> (12, 8),
           new Tuple<int, int> (10, 9),
           new Tuple<int, int> (11, 9),
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

            if (!IsMoveValid())
            {
                transform.position += new Vector3(1, 0, 0);
            }

            isLeftControlPressed = false;
        }

        if (isRightControlPressed)
        {
            transform.position += new Vector3(1, 0, 0);

            if (!IsMoveValid())
            {
                transform.position += new Vector3(-1, 0, 0);
            }

            isRightControlPressed = false;
        }
        
        if (isUpControlPressed)
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);

            if(!IsMoveValid())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }

            isUpControlPressed = false;
        }

        if (isMovingDown)
        {
            transform.position += new Vector3(0, -1, 0);

            if (!IsMoveValid())
            {
                transform.position += new Vector3(0, 1, 0);
                AddBuildingPartsToGrid();
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
            if (grid[patternElementCoordinates.Item1, patternElementCoordinates.Item2] == null)
            {
                return false;
            }
        }

        return true;
    }

    private void AddBuildingPartsToGrid()
    {
        foreach (Transform children in transform)
        {
            int coordinateX = Mathf.RoundToInt(children.transform.position.x);
            int coordinateY = Mathf.RoundToInt(children.transform.position.y);

            grid[coordinateX, coordinateY] = children;
        }
    }

    private bool IsMoveValid()
    {
        foreach (Transform children in transform)
        {
            int coordinateX = Mathf.RoundToInt(children.transform.position.x);
            int coordinateY = Mathf.RoundToInt(children.transform.position.y);

            if (coordinateX < LEFT_BORDER_POSITION_X || coordinateX >= RIGHT_BORDER_POSITION_X || coordinateY >= DOWN_BORDER_POSITION_Y || coordinateY < 0)
            {
                return false;
            }

            if (grid[coordinateX, coordinateY] != null)
            {
                return false;
            }
        }

        return true;
    }
}
