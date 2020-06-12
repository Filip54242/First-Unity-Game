using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGettingShot : MonoBehaviour
{
    public GameObject explosion;
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
            Debug.Log("Cannot find 'GameController' script.");
        }
    }
     void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Boundry"))
        {
            return;
        }
        if (other.tag.Equals("EnemyProjectile"))
        {
            levelManager.GameOver();
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);



    }
}
