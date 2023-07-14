using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtPlayer : MonoBehaviour
{
    public Transform targetObject;
    public float rotationSpeed = 5f;

    private void Update()
    {
        // Calculate the direction towards the target object
        Vector3 targetDirection = targetObject.position - transform.position;
        targetDirection.y = 0f; // Set Y component to 0 to restrict rotation to the XZ plane

        // Calculate the desired rotation towards the target
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        // Set the X rotation to 90 degrees
        //targetRotation.eulerAngles = new Vector3(90f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

        // Smoothly rotate the object towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
