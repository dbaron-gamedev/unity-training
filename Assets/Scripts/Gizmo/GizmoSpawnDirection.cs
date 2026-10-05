using System;
using Unity.VisualScripting;
using UnityEngine;

public class GizmoSpawnDirection : MonoBehaviour
{
    public float maxDistance = 5f;
    
    private bool hit = false;
    
    private void Update()
    {
        // Define origin and direction
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        // Create a container for the hit data
        RaycastHit hitInfo;

        // Cast the ray
        if (Physics.Raycast(origin, direction, out hitInfo, maxDistance))
        {
            Debug.Log("Hit object: " + hitInfo.collider.name);
            hit = true;
        }
        else
        {
            hit = false;
        }
    }
    
    void OnDrawGizmos()
    {
        if (hit)
        {
            DrawSpawnDirection(Color.red);
        }

        else
        {
            DrawSpawnDirection(Color.green);
        }
    }

    void OnDrawGizmosSelected()
    {
        DrawSpawnDirection(Color.yellow);
    }

    void DrawSpawnDirection(Color color)
    {
        Gizmos.color = color;

        // Draw wire sphere for explosion range
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance);

        // Optional: draw a center marker
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
    
}
