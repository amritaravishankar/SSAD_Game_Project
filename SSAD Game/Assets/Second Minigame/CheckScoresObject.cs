using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CheckScoresObject : MonoBehaviour
{
    public Text ScoreText;
    public static int arrowScore;
    public List<List<int>> Solution = new List<List<int>>();
    public List<int> SD = new List<int>();
    public static int ScoreArrow = 0;
    int found = 0;

    public void calcScore(List<int> SD)
    {
        Solution.Add(new List<int> { 1, 1, 1 }); //Adding {source, destination, arrow type} to Solution
        Solution.Add(new List<int> { 2, 2, 2 });
        Solution.Add(new List<int> { 3, 1, 1 });

        foreach (List<int> list in Solution) //To check if Solution contains our {S,D,A} combination
        {
            if (list.SequenceEqual(SD)) //if our {S,D,A} combination exists award 10 points
            {
                ScoreArrow += 10;
                print("Val found");
                found = 1; //flag variable for debugging
                break;
            }
        }
        if (found == 0)
        {
            print("Not found!");  //flag variable and statement for debugging
        }
    }

    public static int FinalScore() //stores the total arrow points in a new static variable
    {
        arrowScore = ScoreArrow;
        print(arrowScore);
        return arrowScore;
    }
}
