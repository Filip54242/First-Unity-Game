using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreUI;
    private int score;
    void Start()
    {
        score = 0;
        UpdateScore();
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
}
