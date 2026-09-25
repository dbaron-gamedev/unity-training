/**
 * Now we can "spin up."
 * The platform gradually spins faster.
**/

using UnityEngine;

public class AngularAcceleraton : MonoBehaviour
{
    public float angularVelocity = 25f;
    public float angularAcceleration = 50f;

    private void Update()
    {
        angularVelocity += angularAcceleration * Time.deltaTime;

        transform.Rotate(
            Vector3.forward * angularVelocity * Time.deltaTime);
    }
}