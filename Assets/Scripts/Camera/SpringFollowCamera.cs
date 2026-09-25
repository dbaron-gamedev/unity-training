using UnityEngine;

public class SpringFollowCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Follow Settings")]
    public Vector3 offset = new Vector3(0f, 3f, -10f);

    [Header("Spring Settings")]
    public float springStrength = 30f; // k
    public float damping = 8f;         // energy loss

    private Vector3 velocity;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Distance from target position
        Vector3 displacement =
            transform.position - desiredPosition;

        // Hooke's Law: F = -k * x
        Vector3 springForce =
            -springStrength * displacement;

        // Damping force: F = -c * v
        Vector3 dampingForce =
            -damping * velocity;

        // Total acceleration
        Vector3 acceleration =
            springForce + dampingForce;

        // Integrate velocity and position
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}