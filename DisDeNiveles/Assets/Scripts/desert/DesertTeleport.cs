using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertTeleport : MonoBehaviour
{
    CharacterController cController;

    [Header("Boundariers")]
    public float xLess = 3000;
    public float xMore = 4000;
    public float zLess = 2000;
    public float zMore = 3000;

    private void Start()
    {
        cController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (transform.position.z < zLess || transform.position.z > zMore)
        {
            if (transform.position.z < zLess)
               cController.transform.position = new Vector3(transform.position.x, transform.position.y, zMore - 0.1f);

            else
                cController.transform.position = new Vector3(transform.position.x, transform.position.y, zLess + 0.1f);               
        }

        if (transform.position.x < xLess || transform.position.x > xMore)
        {
            if (transform.position.x < xLess)
                cController.transform.position = new Vector3(xMore - 0.1f, transform.position.y, transform.position.z);

            else
                cController.transform.position = new Vector3(xLess + 0.1f, transform.position.y, transform.position.z);
        }
    }
}
