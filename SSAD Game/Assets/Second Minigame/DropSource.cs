using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropSource : MonoBehaviour
{
    public Dropdown UseCases;
    private AddArrow a1;

    public void Awake()
    {
        a1 = GameObject.FindObjectOfType<AddArrow>();
    }

    private void Start() //to listen to changes made by user by picking drop down value
    {
        UseCases.onValueChanged.AddListener(delegate {
            UseCasesValueChangeHappened(UseCases);
        });
    }

    public void UseCasesValueChangeHappened(Dropdown sender)
    {
        int x = sender.value; //stores user's chosen value
        a1.MessageS(x); //sends the value so that it can be added to the {source, destination, arrow type} array
    }

}
