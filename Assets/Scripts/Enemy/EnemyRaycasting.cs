using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycasting : MonoBehaviour
{
    public float maxRayDistance = 25.0f;
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            Debug.Log("hit");
            Debug.Log(hit.transform.gameObject.tag);
        }
    }
}
