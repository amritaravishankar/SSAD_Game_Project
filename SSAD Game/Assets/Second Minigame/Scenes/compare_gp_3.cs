using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compare_gp_3 : MonoBehaviour
{
    public static int points_gp_3;
    private string[] ans = { "Use_Case_A", "Use_Case_B"};

   
    void Update() //Function used to compare if the use cases are correctly placed in the right panel and award points
    {
        Image[] images = this.GetComponentsInChildren<Image>(); //checks for child objects of the panel (once dragged into panel)

        int num = 0;
        for(int i=0; i<ans.Length; i++)
        {
            for (int j = 0; j < images.Length; j++)
            {
                if(ans[i] == images[j].name)
                {
                    num++;  //calculates total number of use cases in the right panel
                }
            }
        }

        points_gp_3 = num*20; //for every use case placed in the right panel, award user with 20 points

        Debug.Log("Points in gp 3: " + points_gp_3);
    }
}
