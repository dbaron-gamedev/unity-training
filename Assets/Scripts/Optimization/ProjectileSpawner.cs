using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private float spreadAngle = 30f;
    [SerializeField] private int projectilesPerSecond = 500;

    [SerializeField] private GameObject projectilePrefab;

    private float spawnAccumulator;

    private void Update()
    {
        spawnAccumulator +=
            Time.deltaTime * projectilesPerSecond;

        int spawnCount =
            Mathf.FloorToInt(spawnAccumulator);

        spawnAccumulator -= spawnCount;

        for (int i = 0; i < spawnCount; i++)
            SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        Quaternion rotation = transform.rotation *
            Quaternion.Euler(
                Random.Range(-spreadAngle, spreadAngle),
                Random.Range(-spreadAngle, spreadAngle),
                0f
            );

        Instantiate(
            projectilePrefab,
            transform.position,
            rotation
        );
    }
}
