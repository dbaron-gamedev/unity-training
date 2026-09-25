/**
 * Without damping:
    - Spin speed increases forever
Real objects lose energy.
**/

using UnityEngine;

public class Damping : MonoBehaviour
{
    public float torque = 100f;
    public float inertia = 10f;
    public float damping = 2f;

    private float angularVelocity;

    private void Update()
    {
        float angularAcceleration =
            torque / inertia;

        angularVelocity +=
            angularAcceleration * Time.deltaTime;

        angularVelocity -=
            angularVelocity * damping * Time.deltaTime;

        transform.Rotate(
            Vector3.forward *
            angularVelocity *
            Time.deltaTime);
    }
}