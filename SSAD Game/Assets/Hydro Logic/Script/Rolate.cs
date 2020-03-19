using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolate : MonoBehaviour
{
    public float rotateSpeed; //set it in the  inspector

    void Update()
    {
        rotate(this.rotateSpeed);
    }


    void rotate(float rotateSpeed )
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }
}
