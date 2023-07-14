using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertCar : MonoBehaviour
{
    public float sensibility = 400;
    public Camera PlayerCamera;
    float xRotation = 0f;
    CharacterController controller;
    Vector3 velocity;
    public float speed = 12;
    RaycastHit hit;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        updateMouse();
        updateMove();
    }

    void updateMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


       //PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void updateMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * -speed * Time.deltaTime);
        //controller.Move(-transform.up * 0.01f);

           
    }
}
