using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private DamageType currentDamage;

    public void TakeDamage(float damage, DamageType damageType)
    {
        currentDamage = damageType;
        currentHealth = Mathf.Max(0f, currentHealth - damage);
    }
}