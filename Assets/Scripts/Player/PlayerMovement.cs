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
    float pitch = 0;

    Vector3 GetNormalizedMousePosition()
    {
        Vector2 mousePos = Input.mousePosition;

        return new Vector3(
            (mousePos.x * (boundary.xMax - boundary.xMin)) / Screen.width + boundary.xMin,
            0.0f, (mousePos.y * (boundary.zMax - boundary.zMin)) / Screen.height + boundary.zMin);

    }

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
    void HandleInputs()
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
    void UpdatePosition()
    {

        decreaseCurrentSpeed();
        Vector3 mousePosition = GetNormalizedMousePosition();
        if (Vector3.Distance(mousePosition, transform.position) < 0.5) currentSpeed = 0;
        transform.LookAt(mousePosition);
        horisontalRotation = transform.rotation.eulerAngles.y;

        movement = new Vector3
        (
        -currentSpeed * Mathf.Cos(Mathf.Deg2Rad * horisontalRotation + 90),
        0.0f,
        currentSpeed * Mathf.Sin(Mathf.Deg2Rad * horisontalRotation + 90)
        );
        GetComponent<Rigidbody>().velocity = movement;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
    }

    void Update()
    {

        HandleInputs();
        UpdatePosition();

    }
}
