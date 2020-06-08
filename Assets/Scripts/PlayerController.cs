using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    public Boundry boundry;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public float decelerationFactor = 150.0f;
    public float cruisingSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    private float currentSpeed = 0.0f;
    private Vector3 movement;
    private float horisontalRotation;
    public GameObject shot;
    public Transform shotSpawn;

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
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        }

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
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundry.xMin, boundry.xMax),
            0,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundry.zMin, boundry.zMax)
        );
    }
    void Update()
    {
        handleInputs();
        updatePosition();
    }

}
