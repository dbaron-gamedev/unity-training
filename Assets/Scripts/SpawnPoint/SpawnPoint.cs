using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    void OnDrawGizmos()
    {
        DrawGizmo(Color.red);
    }

    void OnDrawGizmosSelected()
    {
        DrawGizmo(Color.yellow);
    }

    void DrawGizmo(Color color)
    {
        Vector3 pos = transform.position;
        Vector3 dir = transform.forward;
        float length = 1.0f;
        float headLen = 0.25f;
        float headAngle = 20f;
        
        Gizmos.color = color;
        Gizmos.DrawLine(pos, pos + dir * length);
        
        Vector3 right = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 180 + headAngle, 0) * Vector3.forward * headLen;
        Vector3 left = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 180 - headAngle, 0) * Vector3.forward * headLen;
    
        Gizmos.DrawLine(pos + dir, pos + dir + right);
        Gizmos.DrawLine(pos + dir, pos + dir + left);
    }

    void Start()
    {
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
