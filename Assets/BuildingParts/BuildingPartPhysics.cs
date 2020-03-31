using UnityEngine;

public class BuildingPartPhysics : MonoBehaviour
{
    private const float MOVE_DOWN_TIME_DELAY = 1.0f;

    private bool isLeftControlPressed;
    private bool isRightControlPressed;
    private bool isMovingDown;
    private float lastMoveDownUpdateTime;

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

        if (Time.time - lastMoveDownUpdateTime > MOVE_DOWN_TIME_DELAY)
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
            isLeftControlPressed = false;
        }

        if (isRightControlPressed)
        {
            transform.position += new Vector3(1, 0, 0);
            isRightControlPressed = false;
        }

        if (isMovingDown)
        {
            transform.position += new Vector3(0, -1, 0);
            isMovingDown = false;
        }
    }
}
