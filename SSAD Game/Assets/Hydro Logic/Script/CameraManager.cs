using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    bool isMoving = false;
    Vector3 moveToPoint;
    public float cameraSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        moveToPoint = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, moveToPoint, Time.deltaTime * cameraSpeed);
            if (Camera.main.transform.localPosition == moveToPoint)
                isMoving = false;
        }
    }

    public void PanCamera(Vector3 point)
    {
        moveToPoint = point;
        isMoving = true;
    }
}
