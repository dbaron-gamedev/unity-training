using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth = 100f;

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0f, currentHealth - damage);
    }
}