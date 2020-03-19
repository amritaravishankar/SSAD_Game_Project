using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FinalScore : MonoBehaviour
{
    public Text ScoreText;
    public int timerPoints = 0;
    public int TotalScore = 0;
    public float t;

    public void DisplayFinalScore()
    {
        if(Timer.t<300.0) //if time taken by the user to complete the game is 300 seconds, give 20 points
        {
            timerPoints = 20;
        }
        else //if time taken by the user is greater than 300 seconds, award 10 points
        {
            timerPoints = 10;
        }

        //Total points earned by the user are a sum of points earned by placing the right arrows between use cases, placing the 
        //use cases in the correct panel and points for time taken by the user to finish

        TotalScore = CheckScoresObject.ScoreArrow + timerPoints + compare_gp_1.points_gp_1 + compare_gp_2.points_gp_2 + compare_gp_3.points_gp_3;

        ScoreText.text = "You have earned " + TotalScore.ToString() + " points!"; //print points scored to the screen
    }
}
