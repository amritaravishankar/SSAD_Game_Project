using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer: MonoBehaviour //To display Timer and calculate total time used by user to finish the game
{
    public Text timerText; //to display timer on to the screen
    private static float startTime;
    public static float t;
    
    void Start()
    {
        startTime = Time.time;
    }

    void Update() //Updating the time in real-time, as the user is playing the game
    {
        t = Time.time - startTime;

        string minutes = ((int)t/60).ToString();
        string seconds = (t%60).ToString("f0");

        timerText.text = minutes + ":" + seconds;
    }
}
