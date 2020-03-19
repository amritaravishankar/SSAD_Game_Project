using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBox : MonoBehaviour
{

    public GameObject camPoint_Left, camPoint_Right;
    GameObject playerRef;
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerRef.transform.localPosition.x < transform.localPosition.x)
            Camera.main.GetComponent<CameraManager>().PanCamera(camPoint_Right.transform.localPosition); //Player is moving back/left >> Move Camera to the left
        else
            Camera.main.GetComponent<CameraManager>().PanCamera(camPoint_Left.transform.localPosition); //Player is moving forward/right >> Move Camera to the right
    }

}
