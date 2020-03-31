using UnityEngine;

public class BuildingPartPhysics : MonoBehaviour
{
    private const int LEFT_BORDER_POSITION_X = 0;
    private const int RIGHT_BORDER_POSITION_X = 11;
    private const int DOWN_BORDER_POSITION_Y = 20;

    private bool isLeftControlPressed;
    private bool isRightControlPressed;
    private bool isMovingDown;
    private float lastMoveDownUpdateTime;
    public float moveDownTimeDelay = 1.0f;

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

        if (Time.time - lastMoveDownUpdateTime >= (Input.GetKey(KeyCode.DownArrow) ? moveDownTimeDelay/ 10 : moveDownTimeDelay))
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

        if (isMovingDown)
        {
            transform.position += new Vector3(0, -1, 0);

            if (!IsMoveValid())
            {
                transform.position += new Vector3(0, 1, 0);
            }

            isMovingDown = false;
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
        }

        return true;
    }
}
