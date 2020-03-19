using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public Vector2 thrust;
    GameObject player;
    Rigidbody2D rb;
    MouseMove mouseM;
    State s1 ;
    //Button 0 = Evaporation/Melting
    //Button 1 = Precipitation 
    //Button 2 = Condensation/Solidification
    public void changeState(int buttonType)
    {
        player = GameObject.FindWithTag("Player");
        //mouseM = player.GetComponent<MouseMove>();
        s1 = player.GetComponent<State>();
        s1.transformState(buttonType);

        //if (!mouseM.getIsMoving())
        //{
        //    s1.transformState(buttonType);
        //}
    }
    
}
