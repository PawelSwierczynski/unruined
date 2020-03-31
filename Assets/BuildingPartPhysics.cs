using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPartPhysics : MonoBehaviour
{
    private bool isLeftControlPressed;
    private bool isRightControlPressed;

    void Start()
    {
        isLeftControlPressed = false;
        isRightControlPressed = false;
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
    }
}
