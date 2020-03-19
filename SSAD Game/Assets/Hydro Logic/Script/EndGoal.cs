using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(!LevelManager.instance.EndLevel())
        {
            // Level not ended
        }
    }
}
