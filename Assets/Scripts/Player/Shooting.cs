using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float nextFire = 0.0f;
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawn;

    // Update is called once per frame
     void handleInputs()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void Update()
    {
        handleInputs();
    }
}
