using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class AddArrow : MonoBehaviour
{
    public int source;
    public int dest;
    public int arrow;
    public List<int> SD = new List<int>();
    public CheckScoresObject c1;
    public static List<List<int>> UseCaseArrow = new List<List<int>>();

    void Awake()
    {
        c1 = GameObject.FindObjectOfType<CheckScoresObject>(); //initialise object of "Check Scores Object Class" to call it's calcScore() function
    }

    public void MessageS(int source) //aquire the source from drop down
    {
        source = source;
        print(source);
        SD.Add(source);
    }

    public void MessageD(int dest) //aquire the destination from drop down
    {
        dest = dest;
        print(dest);
        SD.Add(dest);
    }

    public void MessageArrow(int arrow) //aquire the arrow type from drop down
    {
        arrow = arrow;
        print(arrow);
        SD.Add(arrow);
    }

    public void printSD() //use the {source,destination,arrow} array
    {
        SD.RemoveAll(i => i == 0);
        foreach (object item in SD)
        {
            print("SD: " + item);
        }

        UseCaseArrow.Add(SD);
        c1.calcScore(SD);
        SD.Clear();

        /*
                if(UseCaseArrow.Contains(SD))
                {
                    print("Already added!");
                }
                else
                {
                  UseCaseArrow.Add(SD);
                  print("Arrow added!");    
                }*/
    }
}

