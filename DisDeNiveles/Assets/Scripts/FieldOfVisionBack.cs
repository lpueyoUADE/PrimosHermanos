using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVisionBack : MonoBehaviour
{
    public float viewRadius = 10f; // Radius of the field of vision
    public float viewAngle = 90f; // Angle of the field of vision

    private void OnDrawGizmosSelected()
    {
        // Draw the field of vision in the Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(-viewAngle * 0.5f + 180f, transform.up) * transform.forward * viewRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(viewAngle * 0.5f + 180f, transform.up) * transform.forward * viewRadius;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            // The player is within the field of vision
            Debug.Log("Player detected!");            
        }
    }

    public bool CanSeePlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, viewRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Player object found within the field of vision
                Vector3 directionToPlayer = collider.transform.position - transform.position;
                float angleToPlayer = Vector3.Angle(directionToPlayer, transform.forward);
                if (angleToPlayer < viewAngle * 0.5f)
                {
                    // No obstacles blocking the line of sight to the player
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, directionToPlayer, out hit, viewRadius))
                    {
                        if (hit.collider.CompareTag("Player"))
                        {
                            // Player is visible within the field of vision
                            return true;
                        }
                    }
                }
            }
        }

        // Player not found or not visible within the field of vision
        return false;
    }
}
