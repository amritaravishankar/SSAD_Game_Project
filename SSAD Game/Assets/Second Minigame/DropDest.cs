using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDest : MonoBehaviour
{
    public Dropdown UseCases;
    private AddArrow a1;

    public void Awake()
    {
        a1 = GameObject.FindObjectOfType<AddArrow>();
    }

    private void Start() //listen's to user's choice from drop down
    {
        UseCases.onValueChanged.AddListener(delegate {
            UseCasesValueChangeHappened(UseCases);
        });
    }

    public void UseCasesValueChangeHappened(Dropdown sender)
    {
        int x = sender.value; //store's user's chosen value in x
        a1.MessageD(x);  //sends the value so that it can be added to the {source, destination, arrow type} array
    }

}
