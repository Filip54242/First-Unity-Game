using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float nextFire = 0.0f;
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform[] shotSpawns;
    void handleInputs()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + 1 / fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            GetComponent<AudioSource>().Play();
        }
    }
    void Update()
    {
        handleInputs();
    }
}
