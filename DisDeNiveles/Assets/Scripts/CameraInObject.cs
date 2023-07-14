using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInObject : MonoBehaviour
{
    public bool rotateWithMouse = true;
    public float sensibility = 400;
    float xRotation = 0f;
    public GameObject car;

    void Update()
    {
        transform.position = car.transform.position;

        if (rotateWithMouse)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.Rotate(Vector3.up * mouseX);
        }        
    }
}
