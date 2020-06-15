using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    static private int level = 1;
    private bool restart;
    private bool isGameOver;
    private bool isLevelFinished;
    public string restartMessage;
    public string nextLevelMessage;
    public string gameOverMessage;
    public string congratulateMessage;
    public Text restartUI;
    public Text gameStatusUI;
    public Text nextLevelUI;
    public AudioClip gameOverSound;
    public AudioClip nextLevelSound;
    public AudioSource audioSource;


    void PlayGameOverSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(gameOverSound);

    }
    void PlayNextLevelSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(nextLevelSound);
    }
    void Start()
    {
        restartUI.text = "";
        gameStatusUI.text = "";
        nextLevelUI.text = "";
        audioSource = GetComponent<AudioSource>();
        GetComponent<LevelCreator>().CreateLevel(level);
    }

    // Update is called once per frame
    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.F))
        {
            level = 1;
            SceneManager.LoadScene("Main");
        }
        if (isLevelFinished && Input.GetKeyDown(KeyCode.X))
        {
            level++;
            SceneManager.LoadScene("Main");
        }
        if (isGameOver)
        {
            restartUI.text = restartMessage;
            restart = true;
        }

    }

    public void FinishedLevel()
    {
        nextLevelUI.text = nextLevelMessage;
        gameStatusUI.text = congratulateMessage;
        isLevelFinished = true;
        PlayNextLevelSound();
    }
    public void GameOver()
    {
        gameStatusUI.text = gameOverMessage;
        isGameOver = true;
        PlayGameOverSound();
        GetComponent<ScoreKeeper>().SetScoreToZero();
    }


}
