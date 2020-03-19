using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class UseCase : ScriptableObject
{
    public new string name;

    public int ID;
    public string Desc;
    public Sprite image;
}
