using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour
{
    public float explosionForce = 800f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 1f;
    public int explosionDamage = 10;

    public KeyCode triggerKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(triggerKey))
            StartCoroutine(ExplosionSequence());
    }

    private IEnumerator ExplosionSequence()
    {
        // TODO: Implement the EmitFlash() method to create a visual flash effect for the explosion.

        yield return new WaitForSeconds(0.1f);
        TriggerBlast();

        // TODO: Implement the EmitSmoke() method to create a smoke effect after the explosion.
        // TODO: Implement the SetDamageZone() method to define the area affected by the explosion for damage calculations.
    }

    public void TriggerBlast()
    {
        Rigidbody[] bodies = FindObjectsByType<Rigidbody>();

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
                health.TakeDamage(50, DamageType.Blast);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        DrawExplosionRadius(Color.red);
    }

    private void OnDrawGizmosSelected()
    {
        DrawExplosionRadius(Color.yellow);
    }

    private void DrawExplosionRadius(Color color)
    {
        Gizmos.color = color;

        // Draw wire sphere for explosion range
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        // Optional: draw a center marker
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}