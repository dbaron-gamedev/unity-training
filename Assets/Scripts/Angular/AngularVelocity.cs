/**
 * Instead of directly rotating, store the rotation speed.
 * Now the object's state contains:
    - Orientation
    - Angular velocity
**/

using UnityEngine;

public class AngularVelocity : MonoBehaviour
{
    public float angularVelocity;
  
    void Update()
    {
        transform.Rotate(
            Vector3.forward * angularVelocity * Time.deltaTime);
    }
}