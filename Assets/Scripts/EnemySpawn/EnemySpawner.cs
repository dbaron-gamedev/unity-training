using UnityEngine;

public class EnemySpawner : MonoBehaviour
{private Vector3 coordinates = new Vector3(0,0,0);
    private Quaternion rotation;
    
 
    void Start()
    {
        enemyCoordinates();
        enemyRotation();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    private void enemyCoordinates()
    {
        float coordinatesX = Random.Range(-5f, 5f);
        float coordinatesY = 1;
        float coordinatesZ = Random.Range(-5f, 5f);
        
        coordinates = new (coordinatesX, coordinatesY, coordinatesZ);
        Debug.Log(coordinates);
    }

    private void enemyRotation()
    {
        rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }

    private void Spawn()
    {
        
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        enemy.transform.position = coordinates;
        enemy.transform.rotation = rotation;
        enemyCoordinates();
        enemyRotation();

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        DrawEnemySpawnPosition();
    }

    void DrawEnemySpawnPosition()
    {
        
        
        Gizmos.matrix = Matrix4x4.TRS(
            coordinates,
            rotation,
            Vector3.one
        );
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(1, 1, 1));
        Gizmos.DrawLine(Vector3.zero,new Vector3(1, 0, 0) );
    }
}
