using UnityEngine;

public class StableSpringSphere : MonoBehaviour
{
    [Header("Anchor (rest reference point)")]
    public Transform anchor;

    [Header("Spring Settings")]
    public float springStrength = 30f;
    public float damping = 6f;

    [Header("Physics")]
    public float mass = 1f;

    private Vector3 velocity;

    void Start()
    {
        velocity = Vector3.down;
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        // Gravity force
        Vector3 gravity = Physics.gravity * mass;

        // Spring displacement
        Vector3 displacement = transform.position - anchor.position;

        // Spring force (Hooke's Law)
        Vector3 springForce = -springStrength * displacement;

        // Damping force
        Vector3 dampingForce = -damping * velocity;

        // Total force
        Vector3 force = springForce + dampingForce + gravity;

        // Acceleration (F = m a)
        Vector3 acceleration = force / mass;

        // Integrate velocity
        velocity += acceleration * dt;

        // Integrate position
        transform.position += velocity * dt;
    }
}