using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

// this class needs refinement, isn't integrated in this version 

public class RemoveArrowObject : MonoBehaviour
{
    private AddArrow a1;
    public List<List<int>> UseCaseArrow = new List<List<int>>();
    public List<int> SD = new List<int>();
    public String removed;
    public int i = 0;

    void Awake()
    {
        a1 = GameObject.FindObjectOfType<AddArrow>();
    }

    public void RemoveFunction(List<List<int>> UseCaseArrow)
    {
        foreach (List<int> list1 in UseCaseArrow)
        {
            foreach (object SD1 in list1)
            {
                print("use case before: " + SD1);
            }
        }

        foreach (List<int> list in UseCaseArrow)
        {
            if (list.SequenceEqual(SD))
            {
                i = UseCaseArrow.IndexOf(list);
                print("Arrow Removed!");
            }
            else
            {
                print("No such arrow");
            }
        }

        UseCaseArrow.RemoveAt(i);

        foreach (object item in SD)
        {
            removed += item.ToString() + " ";
        }
       // RemoveText.text = "Removed: " + removed.ToString();
    }
}
