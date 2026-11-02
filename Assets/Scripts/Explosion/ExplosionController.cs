using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public float explosionForce = 800f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 1f;
    public int explosionDamage = 10;

    public KeyCode triggerKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            Explode();
        }
    }

    public void Explode()
    {
        Rigidbody[] bodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rb in bodies)
        {
            rb.AddExplosionForce(
                explosionForce,
                transform.position,
                explosionRadius,
                upwardsModifier,
                ForceMode.Impulse
            );

            if (rb.TryGetComponent<Health>(out Health health))
                health.TakeDamage(50);
        }

        Destroy(gameObject);
    }

    // 💥 Gizmo visualization (always visible in editor if gizmos enabled)
    void OnDrawGizmos()
    {
        DrawExplosionRadius(Color.red);
    }

    // 🎯 Only shows when selected (cleaner for big scenes)
    void OnDrawGizmosSelected()
    {
        DrawExplosionRadius(Color.yellow);
    }

    void DrawExplosionRadius(Color color)
    {
        Gizmos.color = color;

        // Draw wire sphere for explosion range
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        // Optional: draw a center marker
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}