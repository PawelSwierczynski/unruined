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
           new Tuple<int, int> (10, 22),
           new Tuple<int, int> (11, 22),
           new Tuple<int, int> (9, 21),
           new Tuple<int, int> (10, 21),
           new Tuple<int, int> (11, 21),
           new Tuple<int, int> (12, 21),
           new Tuple<int, int> (8, 20),
           new Tuple<int, int> (9, 20),
           new Tuple<int, int> (10, 20),
           new Tuple<int, int> (11, 20),
           new Tuple<int, int> (12, 20),
           new Tuple<int, int> (13, 20),
           new Tuple<int, int> (7, 19),
           new Tuple<int, int> (8, 19),
           new Tuple<int, int> (9, 19),
           new Tuple<int, int> (10, 19),
           new Tuple<int, int> (11, 19),
           new Tuple<int, int> (12, 19),
           new Tuple<int, int> (13, 19),
           new Tuple<int, int> (14, 19),
           new Tuple<int, int> (6, 18),
           new Tuple<int, int> (7, 18),
           new Tuple<int, int> (8, 18),
           new Tuple<int, int> (9, 18),
           new Tuple<int, int> (10, 18),
           new Tuple<int, int> (11, 18),
           new Tuple<int, int> (12, 18),
           new Tuple<int, int> (13, 18),
           new Tuple<int, int> (14, 18),
           new Tuple<int, int> (15, 18),
           new Tuple<int, int> (5, 17),
           new Tuple<int, int> (6, 17),
           new Tuple<int, int> (7, 17),
           new Tuple<int, int> (8, 17),
           new Tuple<int, int> (9, 17),
           new Tuple<int, int> (10, 17),
           new Tuple<int, int> (11, 17),
           new Tuple<int, int> (12, 17),
           new Tuple<int, int> (13, 17),
           new Tuple<int, int> (14, 17),
           new Tuple<int, int> (15, 17),
           new Tuple<int, int> (16, 17),
           new Tuple<int, int> (4, 16),
           new Tuple<int, int> (5, 16),
           new Tuple<int, int> (6, 16),
           new Tuple<int, int> (7, 16),
           new Tuple<int, int> (8, 16),
           new Tuple<int, int> (9, 16),
           new Tuple<int, int> (10, 16),
           new Tuple<int, int> (11, 16),
           new Tuple<int, int> (12, 16),
           new Tuple<int, int> (13, 16),
           new Tuple<int, int> (14, 16),
           new Tuple<int, int> (15, 16),
           new Tuple<int, int> (16, 16),
           new Tuple<int, int> (17, 16),
           new Tuple<int, int> (3, 15),
           new Tuple<int, int> (4, 15),
           new Tuple<int, int> (5, 15),
           new Tuple<int, int> (6, 15),
           new Tuple<int, int> (7, 15),
           new Tuple<int, int> (8, 15),
           new Tuple<int, int> (9, 15),
           new Tuple<int, int> (10, 15),
           new Tuple<int, int> (11, 15),
           new Tuple<int, int> (12, 15),
           new Tuple<int, int> (13, 15),
           new Tuple<int, int> (14, 15),
           new Tuple<int, int> (15, 15),
           new Tuple<int, int> (16, 15),
           new Tuple<int, int> (17, 15),
           new Tuple<int, int> (18, 15),
           new Tuple<int, int> (2, 14),
           new Tuple<int, int> (3, 14),
           new Tuple<int, int> (4, 14),
           new Tuple<int, int> (5, 14),
           new Tuple<int, int> (6, 14),
           new Tuple<int, int> (7, 14),
           new Tuple<int, int> (8, 14),
           new Tuple<int, int> (9, 14),
           new Tuple<int, int> (10, 14),
           new Tuple<int, int> (11, 14),
           new Tuple<int, int> (12, 14),
           new Tuple<int, int> (13, 14),
           new Tuple<int, int> (14, 14),
           new Tuple<int, int> (15, 14),
           new Tuple<int, int> (16, 14),
           new Tuple<int, int> (17, 14),
           new Tuple<int, int> (18, 14),
           new Tuple<int, int> (19, 14),
           new Tuple<int, int> (5, 13),
           new Tuple<int, int> (6, 13),
           new Tuple<int, int> (7, 13),
           new Tuple<int, int> (8, 13),
           new Tuple<int, int> (9, 13),
           new Tuple<int, int> (10, 13),
           new Tuple<int, int> (11, 13),
           new Tuple<int, int> (12, 13),
           new Tuple<int, int> (13, 13),
           new Tuple<int, int> (14, 13),
           new Tuple<int, int> (15, 13),
           new Tuple<int, int> (16, 13),
           new Tuple<int, int> (5, 12),
           new Tuple<int, int> (6, 12),
           new Tuple<int, int> (7, 12),
           new Tuple<int, int> (8, 12),
           new Tuple<int, int> (9, 12),
           new Tuple<int, int> (10, 12),
           new Tuple<int, int> (11, 12),
           new Tuple<int, int> (12, 12),
           new Tuple<int, int> (13, 12),
           new Tuple<int, int> (14, 12),
           new Tuple<int, int> (15, 12),
           new Tuple<int, int> (16, 12),
           new Tuple<int, int> (5, 11),
           new Tuple<int, int> (6, 11),
           new Tuple<int, int> (7, 11),
           new Tuple<int, int> (8, 11),
           new Tuple<int, int> (9, 11),
           new Tuple<int, int> (10, 11),
           new Tuple<int, int> (11, 11),
           new Tuple<int, int> (12, 11),
           new Tuple<int, int> (13, 11),
           new Tuple<int, int> (14, 11),
           new Tuple<int, int> (15, 11),
           new Tuple<int, int> (16, 11),
           new Tuple<int, int> (5, 10),
           new Tuple<int, int> (6, 10),
           new Tuple<int, int> (7, 10),
           new Tuple<int, int> (8, 10),
           new Tuple<int, int> (9, 10),
           new Tuple<int, int> (10, 10),
           new Tuple<int, int> (11, 10),
           new Tuple<int, int> (12, 10),
           new Tuple<int, int> (13, 10),
           new Tuple<int, int> (14, 10),
           new Tuple<int, int> (15, 10),
           new Tuple<int, int> (16, 10),
           new Tuple<int, int> (5, 9),
           new Tuple<int, int> (6, 9),
           new Tuple<int, int> (7, 9),
           new Tuple<int, int> (8, 9),
           new Tuple<int, int> (9, 9),
           new Tuple<int, int> (10, 9),
           new Tuple<int, int> (11, 9),
           new Tuple<int, int> (12, 9),
           new Tuple<int, int> (13, 9),
           new Tuple<int, int> (14, 9),
           new Tuple<int, int> (15, 9),
           new Tuple<int, int> (16, 9),
           new Tuple<int, int> (5, 8),
           new Tuple<int, int> (6, 8),
           new Tuple<int, int> (7, 8),
           new Tuple<int, int> (8, 8),
           new Tuple<int, int> (9, 8),
           new Tuple<int, int> (10, 8),
           new Tuple<int, int> (11, 8),
           new Tuple<int, int> (12, 8),
           new Tuple<int, int> (13, 8),
           new Tuple<int, int> (14, 8),
           new Tuple<int, int> (15, 8),
           new Tuple<int, int> (16, 8),
           new Tuple<int, int> (5, 7),
           new Tuple<int, int> (6, 7),
           new Tuple<int, int> (7, 7),
           new Tuple<int, int> (8, 7),
           new Tuple<int, int> (9, 7),
           new Tuple<int, int> (10, 7),
           new Tuple<int, int> (11, 7),
           new Tuple<int, int> (12, 7),
           new Tuple<int, int> (13, 7),
           new Tuple<int, int> (14, 7),
           new Tuple<int, int> (15, 7),
           new Tuple<int, int> (16, 7),
           new Tuple<int, int> (5, 6),
           new Tuple<int, int> (6, 6),
           new Tuple<int, int> (7, 6),
           new Tuple<int, int> (8, 6),
           new Tuple<int, int> (9, 6),
           new Tuple<int, int> (10, 6),
           new Tuple<int, int> (11, 6),
           new Tuple<int, int> (12, 6),
           new Tuple<int, int> (13, 6),
           new Tuple<int, int> (14, 6),
           new Tuple<int, int> (15, 6),
           new Tuple<int, int> (16, 6),
           new Tuple<int, int> (5, 5),
           new Tuple<int, int> (6, 5),
           new Tuple<int, int> (7, 5),
           new Tuple<int, int> (8, 5),
           new Tuple<int, int> (13, 5),
           new Tuple<int, int> (14, 5),
           new Tuple<int, int> (15, 5),
           new Tuple<int, int> (16, 5),
           new Tuple<int, int> (5, 4),
           new Tuple<int, int> (6, 4),
           new Tuple<int, int> (7, 4),
           new Tuple<int, int> (8, 4),
           new Tuple<int, int> (13, 4),
           new Tuple<int, int> (14, 4),
           new Tuple<int, int> (15, 4),
           new Tuple<int, int> (16, 4),
           new Tuple<int, int> (5, 3),
           new Tuple<int, int> (6, 3),
           new Tuple<int, int> (7, 3),
           new Tuple<int, int> (8, 3),
           new Tuple<int, int> (13, 3),
           new Tuple<int, int> (14, 3),
           new Tuple<int, int> (15, 3),
           new Tuple<int, int> (16, 3),
           new Tuple<int, int> (5, 2),
           new Tuple<int, int> (6, 2),
           new Tuple<int, int> (7, 2),
           new Tuple<int, int> (8, 2),
           new Tuple<int, int> (13, 2),
           new Tuple<int, int> (14, 2),
           new Tuple<int, int> (15, 2),
           new Tuple<int, int> (16, 2),
           new Tuple<int, int> (5, 1),
           new Tuple<int, int> (6, 1),
           new Tuple<int, int> (7, 1),
           new Tuple<int, int> (8, 1),
           new Tuple<int, int> (13, 1),
           new Tuple<int, int> (14, 1),
           new Tuple<int, int> (15, 1),
           new Tuple<int, int> (16, 1),

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
