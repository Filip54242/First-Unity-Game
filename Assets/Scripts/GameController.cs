using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private int score;
    private bool isGameOver;
    private bool restart;
    private bool isLevelFinished;
    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreUI;
    public Text restartUI;
    public Text gameOverUI;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (isGameOver)
            {
                restartUI.text = "Press 'R' for restart.";
                restart = true;
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }

    }

    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void UpdateScore()
    {
        scoreUI.text = score.ToString();
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }
    void Start()
    {
        score = 0;
        UpdateScore();
        restart = false;
        isGameOver = false;
        restartUI.text = "";
        gameOverUI.text = "";
        StartCoroutine(SpawnWaves());

    }

    public void GameOver()
    {
        gameOverUI.text = "Game Over !";
        isGameOver = true;
    }
}
