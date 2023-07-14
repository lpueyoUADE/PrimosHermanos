using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public Camera PlayerCamera;
    public Transform GroundCheck;
    public LayerMask groundMask;
    public float groundDistance = .4f;
    public float sensibility = 400;

    public float jumpHeight = 3f;
    public float speed = 12;
    public float gravity = -10f;

    [Header("Interactions")]
    public Transform InteractionCheck;
    public LayerMask interactionMask;

    float xRotation = 0f;
    CharacterController controller;
    bool isGrounded;

    RaycastHit hit;
    bool m_HitDetect;
    float interactionMaxDistance = 3f;

    [Header("Steps")]
    public AudioSource stepsAudioSrc;
    public float delayBetweenSteps = 0.48f;
    public AudioClip[] currentStepsSound;
    private bool isMoving = false;
    private float currentDelay = 0;
    
    Vector3 velocity;
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
        interact();
        UpdateStepsSounds();
    }

    void updateMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void updateMove()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if ((x != 0 || z != 0) && isGrounded)
            isMoving = true;
        else
            isMoving = false;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {          
            if(Physics.Raycast(
                InteractionCheck.position,
                InteractionCheck.forward,
                out hit,
                interactionMaxDistance
            ))
            {               
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Interaction"))
                {
                    Interactable interactable = hit.transform.gameObject.GetComponent<Interactable>();
                    interactable.Interact();
                }                
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;        
        Gizmos.DrawRay(InteractionCheck.position, InteractionCheck.forward * interactionMaxDistance);
    }

    void UpdateStepsSounds()
    {
        if (isMoving)
        {
            if (currentDelay >= delayBetweenSteps)
                PlayStepSound();
            else
                currentDelay += Time.deltaTime;
        }
        else
            currentDelay = 0;

    }

    void PlayStepSound()
    {
        currentDelay = 0;
        if (stepsAudioSrc != null && currentStepsSound.Length != 0)
            stepsAudioSrc.PlayOneShot(currentStepsSound[Random.Range(0, currentStepsSound.Length)]);
    }
}