using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryControl : MonoBehaviour
{
    public LayerMask mask;
    private LevelManager levelManager;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            levelManager = gameControllerObject.GetComponent<LevelManager>();
        }
        if (levelManager == null)
        {
            Debug.Log("Cannot find 'LevelManager' script.");
        }
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);

    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox
        (
            gameObject.transform.position,
            transform.localScale / 2,
            Quaternion.identity
        );
        if (colliders.Length == 2)
        {
            if (colliders[0].gameObject.tag.Equals("Player") || colliders[1].gameObject.tag.Equals("Player"))
            { levelManager.FinishedLevel(); }
        }
    }
}
