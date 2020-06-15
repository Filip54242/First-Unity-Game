using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreUI;
    static private int score = 0;
    void Start()
    {
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
    public void SetScoreToZero()
    {
        score = 0;
    }
}
