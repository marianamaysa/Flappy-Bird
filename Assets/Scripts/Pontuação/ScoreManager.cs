using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Score Gameplay")]
    [SerializeField] private int score = 0;
    [SerializeField] TextMeshProUGUI scoreTxt;

    [Header("Score GameOver")]
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [SerializeField] TextMeshProUGUI currentScoreTxt;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        score = 0;
        UpdateScore();

        if(highScoreTxt != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreTxt.text = "High Score: " + highScore.ToString();
        }

        //currentScore.text = currentScore.ToString();

        //highScore.text = PlayerPrefs.GetInt("Best Score", 0).ToString();
        //UpdadeHighScore();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void UpdateScore()
    {
        if(scoreTxt != null)
        {
            scoreTxt.text = "Score" + score.ToString();
        }
    }

    public void GameOverScore()
    {
        Debug.Log("oii");
        if (currentScoreTxt != null)
        {
            currentScoreTxt.text = "Score: " + score.ToString();
        }

        int storedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > storedHighScore)
        {
            storedHighScore = score;
            PlayerPrefs.SetInt("HighScore", storedHighScore);

            if (highScoreTxt != null)
            {
                highScoreTxt.text = "High Score: " + storedHighScore.ToString();
            }
        }
    }

    public int CurrentScore
    {
        get { return score; }
    }

}
