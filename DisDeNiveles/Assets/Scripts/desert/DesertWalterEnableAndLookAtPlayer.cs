using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertWalterEnableAndLookAtPlayer : Interactable
{
    public UISimpleSubtitlesObject walterArrest;
    public AudioSource audioSrc;
    public AudioSource otherAudioSrc;
    public Transform targetObject;
    public Rigidbody rBody;
    public float rotationSpeed = 5f;
    public float minZ = 2680;
    public float maxZ = 2620;
    public GameObject playerShovel;

    public DesertDirtyMoney2 ddm2;

    private void Start()
    {
        playerShovel.SetActive(false);
    }

    public override void Interact()
    {
        base.Interact();
        audioSrc.Play();
        otherAudioSrc.Play();
        walterArrest.StartExec();
        ddm2.RiseHankCar();
        _alreadyInteracted = true;
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Calculate the direction towards the target object
        Vector3 targetDirection = targetObject.position - transform.position;
        targetDirection.y = 0f; // Set Y component to 0 to restrict rotation to the XZ plane

        // Calculate the desired rotation towards the target
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        // Set the X rotation to 90 degrees
        targetRotation.eulerAngles = new Vector3(90f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

        // Smoothly rotate the object towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
