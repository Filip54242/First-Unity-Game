using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float engagedSpeed;
    public float surveillanceSpeed;
    public float distanceToTake = 10;
    public Boundary boundary;

    private GameObject player;
    private bool playerFound;
    private Vector3 target;

    void Start()
    {
        player = null;
        playerFound = false;
        GetNewTarget();

    }
    void GoTo(Vector3 destination, float speed)
    {
        Vector3 currentDestination = destination - transform.position;
        destination.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards
            (
            transform.rotation,
            Quaternion.LookRotation(currentDestination),
            speed
            );
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void Surveillance()
    {
        if (Vector3.Distance(target, transform.position) < GetComponent<EnemyShooting>().range/2)
        {
            GetNewTarget();
        }
        GoTo(target, surveillanceSpeed);
    }
    void FollowPlayer()
    {
        GoTo(player.transform.position, engagedSpeed);
    }

    void ChangeTargetToAvoidColission()
    {
        int direction = (new int[] { 1, -1 })[Random.Range(0, 2)];
        target = new Vector3
        (
        -distanceToTake * Mathf.Cos(Mathf.Deg2Rad * 90 * direction) + transform.position.x,
        0.0f,
        distanceToTake * Mathf.Sin(Mathf.Deg2Rad * 90 * direction) + transform.position.z
        );
        
    }
    void GetNewTarget()
    {
        target = new Vector3(Random.Range(boundary.xMin, boundary.xMax), 0.0f, Random.Range(boundary.zMin, boundary.zMax));
    }


    void Update()
    {
        if (playerFound && player != null)
        {
            FollowPlayer();
        }
        else
        {
            Surveillance();
        }
    }
    public void engageAvoidanceRoutine()
    {
        ChangeTargetToAvoidColission();
    }
    public void PlayerFound(GameObject found)
    {
        player = found;
        playerFound = true;
    }
}
