using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private int score = 0;
    [SerializeField] TextMeshProUGUI scoreTxt;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    public void AddScore(int amount)
    {
        score += amount;
        if(scoreTxt != null)
        {
            scoreTxt.text = "Score: " + score.ToString();
        }
    }
}
