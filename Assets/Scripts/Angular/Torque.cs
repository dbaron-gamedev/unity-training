using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Torque : MonoBehaviour
{
    [Header("Physics")]
    [Tooltip("Applied torque (N·m)")]
    public float torque = 100f;

    [Tooltip("Moment of inertia (kg·m²)")]
    public float inertia = 10f;

    [Header("State")]
    [Tooltip("Angular acceleration (rad/s²)")]
    public float angularAcceleration = 0f;

    [Tooltip("Angular velocity (rad/s)")]
    public float angularVelocity = 0f;

    [Tooltip("Angular displacement (rad)")]
    public float angle = 0f;

    private Material _material;

    private void Start()
    {
        // Get the object's material instance
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Prevent invalid moment of inertia
        if (inertia <= 0f) return;

        // Calculate angular acceleration
        angularAcceleration = torque / inertia;

        // Update angular velocity
        angularVelocity += angularAcceleration * Time.deltaTime;

        // Update angular displacement
        angle += angularVelocity * Time.deltaTime;

        // Keep the angle within one full rotation CLAMPING
        angle = Mathf.Repeat(angle, 2f * Mathf.PI);

        // Send the angle to Shader Graph
        _material.SetFloat("_Angle", angle);


        float colorRed = angularVelocity;

        _material.SetFloat("_ColorRed", colorRed);
    }

    private void OnDestroy()
    {
        // Release the material instance
        if (_material != null)
            Destroy(_material);
    }
}