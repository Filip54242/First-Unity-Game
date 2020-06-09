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
    public string restartMessage = "press 'f' to pay respects... i mean to restart";
    public string nextLevelMessage = "press 'x' to doubt.. i mean to go to the next level";
    public string gameOverMessage = "game over!";
    public string congratulateMessage="level passed!";
    public Text restartUI;
    public Text gameStatusUI;
    public Text nextLevelUI;

    void Start()
    {
        restartUI.text = "";
        gameStatusUI.text = "";
        nextLevelUI.text = "";
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
        nextLevelUI.text=nextLevelMessage;
        gameStatusUI.text=congratulateMessage;
        isLevelFinished=true;
    }
    public void GameOver()
    {
        gameStatusUI.text = gameOverMessage;
        isGameOver = true;
    }


}
