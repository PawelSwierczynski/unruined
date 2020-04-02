using UnityEngine;

public class BuildingPartPhysics : MonoBehaviour
{
    private MoveValidator moveValidator;

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

                enabled = false;
                //FindObjectOfType<SpawnBuildingParts>().SpawnNewBuildingPart();
            }

            isMovingDown = false;
        }
    }

    /*private bool IsLevelCompleted()
    {
        foreach (var patternElementCoordinates in patternCoordinates)
        {
            if (buildingPartGridHolder.IsCellFree(patternElementCoordinates))
            {
                return false;
            }
        }

        return true;
    }*/
}
