/**
 * Torque:
 * Imagine torque as a person pushing.
    - Torque = how hard they push
    - Inertia = how stubborn the object is
**/

using UnityEngine;

public class Torque : MonoBehaviour
{
    [Header("Physics"), Tooltip("Newton-meters (N·m)")]
    public float torque = 100f;

    // Inertia is an object's resistance to changes in motion.
    [Tooltip("Wow the mass is distributed relative to the axis of rotation (kg·m²)")]
    public float inertia = 10f;

    [Header("State")]
    public float angularVelocity = 25f;

    private void Update()
    {
        // Calculate angular acceleration from torque
        float angularAcceleration = torque / inertia;

        // Update angular velocity
        angularVelocity += angularAcceleration * Time.deltaTime;

        // Rotate object
        transform.Rotate(
            Vector3.forward * angularVelocity * Time.deltaTime);
    }
}