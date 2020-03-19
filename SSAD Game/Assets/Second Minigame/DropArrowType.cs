using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArrowType : MonoBehaviour
{
    public Dropdown UseCases;
    private AddArrow a1;

    public void Awake()
    {
        a1 = GameObject.FindObjectOfType<AddArrow>();
    }

    private void Start()
    {
        UseCases.onValueChanged.AddListener(delegate { //listen to user's picked choice from drop-down
            UseCasesValueChangeHappened(UseCases);
        });
    }

    public void UseCasesValueChangeHappened(Dropdown sender)
    {
        int x = sender.value; //stores user's chosen value in x
        a1.MessageArrow(x);  //sends the value so that it can be added to the {source, destination, arrow type} array
    }

}
