using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDoor : Interactable
{
    [Header("Generic Door Script")]
    public AudioClip openSFX;
    public AudioClip lockedSFX;

    [Range(0.1f, 180)] public float maxRotation = 90;
    [Range(0.1f, 2f)] public float openingSpeed = 1.2f;

    public GameObject pivot;

    [Header("Door Openers")]
    public bool isLocked = false;
    public Button[] openers;

    float _minRotation = 5;
    bool _isClosed = true;
    bool _transitioning = false;

    AudioSource _audioSRC;
    private void Start()
    {
        _audioSRC = GetComponent<AudioSource>();
        _isClosed = true;
    }

    public override void Interact()
    {
        if (_transitioning || !isInteractable())
            return;
        
        if (isLocked)
        {
            _audioSRC.PlayOneShot(lockedSFX);
            return;
        }

        base.Interact();

        _transitioning = true;
        _audioSRC.PlayOneShot(openSFX);
    }

    private void Update()
    {
        CheckOpeners();

        if(_transitioning)
        {
            if (_isClosed)
                Open();
            else
                Close();
        }
    }
    private void CheckOpeners()
    {
        foreach (Button opener in openers)
        {
            if (!opener.getAlreadyInteracted())
            {
                isLocked = true;
                return;
            }
        }

        isLocked = false;
    }

    private void Open()
    {
        if (transform.rotation.eulerAngles.y >= maxRotation)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, maxRotation, transform.rotation.z);
            _transitioning = false;
            _isClosed = false;
            return;
        }

        transform.RotateAround(pivot.transform.position, Vector3.up, Time.deltaTime + openingSpeed);
    }

    private void Close()
    {
        if (transform.rotation.eulerAngles.y <= _minRotation)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            _transitioning = false;
            _isClosed = true;
            return;
        }

        transform.RotateAround(pivot.transform.position, Vector3.up, -(Time.deltaTime + openingSpeed));
    }
}
