/**
This rotates at:

90 degrees per second
around the Y axis

This works, but it's not physics-based.
**/

using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed = 90f;

    private void Update()
    {
        transform.Rotate(
            Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}