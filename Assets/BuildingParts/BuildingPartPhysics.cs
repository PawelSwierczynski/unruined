using UnityEngine;

public class BuildingPartPhysics : MonoBehaviour
{
    private const int LEFT_BORDER_POSITION_X = 0;
    private const int RIGHT_BORDER_POSITION_X = 11;
    private const int DOWN_BORDER_POSITION_Y = 20;

    private static Transform[,] grid = new Transform[RIGHT_BORDER_POSITION_X, DOWN_BORDER_POSITION_Y];
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
                this.enabled = false;
                FindObjectOfType<SpawnBuildingParts>().SpawnNewBuildingPart();
            }

            isMovingDown = false;
        }
    }

    void AddBuildingPartsToGrid()
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

            if(grid[coordinateX, coordinateY] != null)
            {
                return false;
            }
        }

        return true;
    }
}
