using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour
{
    private float currentSpeed = 0.0f;
    private Vector3 movement;
    private float horisontalRotation;
    public Boundary boundary;
    public float decelerationFactor = 150.0f;
    public float cruisingSpeed = 5.0f;
    public float rotationSpeed = 2.0f;

    void decreaseCurrentSpeed()
    {

        if (currentSpeed - (cruisingSpeed / decelerationFactor) > 0)
        {
            currentSpeed -= cruisingSpeed / decelerationFactor;
        }
        else
        {
            currentSpeed = 0.0f;
        }
    }
    void handleInputs()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-rotationSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(rotationSpeed, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed = cruisingSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentSpeed = 0;
        }
    }
    void updatePosition()
    {

        decreaseCurrentSpeed();
        horisontalRotation = transform.rotation.eulerAngles.y;

        movement = new Vector3
        (
        -currentSpeed * Mathf.Cos(Mathf.Deg2Rad * horisontalRotation),
        0.0f,
        currentSpeed * Mathf.Sin(Mathf.Deg2Rad * horisontalRotation)
        );
        GetComponent<Rigidbody>().velocity = movement;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
    }

    // Update is called once per frame
    void Update()
    {
        handleInputs();
        updatePosition();
    }


    // Update is called once per frame
}
