using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifetime = 3f;

    private float timer;

    private void Update()
    {
        transform.position +=
            transform.forward * speed * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= lifetime)
            Destroy(gameObject);
    }
}