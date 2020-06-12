using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private float nextFire = 0.0f;
    public float fireRate = 0.5f;
    public float range;
    public GameObject shot;
    public Transform[] shotSpawns;
    void Update()
    {
        Ray ray = new Ray(transform.position, gameObject.transform.TransformDirection(Vector3.forward));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.transform.gameObject.tag.Equals("Player") && Time.time > nextFire)
            {
                nextFire = Time.time + 1 / fireRate;
                foreach (Transform shotSpawn in shotSpawns)
                {
                    GetComponent<AudioSource>().Play();
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }
            }
        }
    }
}
