using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float score;
    public Text scoreText;

    void Start()
    {
        score = 0f;
        scoreText.text = "Score: " + score;
    }

    void ScorePoints(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score;
    }
}
