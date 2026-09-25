using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class Planche : MonoBehaviour
{
    public float speed = 8f;

    public float topBound = 4f;
    public float bottomBound = -4f;

    public Vector2 velocity;
    public float angle = 0;
    public float dirX;

    private void Start()
    {
        Launch();
        StartCoroutine(randomDir());
    }

    void Update()
    {
        Move();
        CheckWallBounce();
    }

    void Launch()
    {
        dirX = Random.value < 0.5f ? -1 : 1;

        velocity = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad),dirX).normalized * speed;
    }

    void Move()
    {
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }

    void CheckWallBounce()
    {
        // Top / Bottom
        if (transform.position.y >= topBound && velocity.y > 0)
        {
            velocity.y *= -1;
            transform.position = new Vector3(transform.position.x, topBound, 0);
        }

        if (transform.position.y <= bottomBound && velocity.y < 0)
        {
            velocity.y *= -1;
            transform.position = new Vector3(transform.position.x, bottomBound, 0);
        }
    }

    private IEnumerator randomDir()
    {
        yield return new WaitForSeconds(1);
        float randomFloat = Random.Range(-10.0f, 10.0f);
        if (randomFloat > 3)
        {
            velocity.y *= -1;
        }

        StartCoroutine(randomDir());

        yield return null;
    }
}
