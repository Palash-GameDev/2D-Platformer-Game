using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        RefreshUi();
    }
   public void IncreaseScore(int increment)
   {
        score += increment;
        RefreshUi();
   }

    private void RefreshUi()
    {
        scoreText.text = "Score : " + score;
    }
}
