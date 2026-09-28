using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 direction;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}