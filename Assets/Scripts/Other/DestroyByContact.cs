using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public int scoreValue;
    private LevelManager levelManager;
    private ScoreKeeper scoreKeeper;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            levelManager = gameControllerObject.GetComponent<LevelManager>();
            scoreKeeper = gameControllerObject.GetComponent<ScoreKeeper>();
        }
        if (levelManager == null)
        {
            Debug.Log("Cannot find 'GameController' script.");
        }
         if (scoreKeeper == null)
        {
            Debug.Log("Cannot find 'ScoreKeeper' script.");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundry")
        {
            return;
        }
        if (other.tag == "Player")
        {
            levelManager.GameOver();
        }
        if (other.tag == "PlayerProjectile")
        {
            scoreKeeper.AddScore(scoreValue);
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);



    }
}
