using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    //holding score
    //we increased our score in our Player Controller Script
    public static int score;
    public Text scoreText;

    void Start()
    {
        score = 0;
    }

    
    void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
