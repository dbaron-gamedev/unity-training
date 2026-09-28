using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 8f;

    public float topBound = 4.5f;
    public float bottomBound = -4.5f;
    public float leftBound = -12f;
    public float rightBound = 8f;

    public float boost = 2f;

    public Transform paddle;

    private Vector2 velocity;
    private float saveSpeed = 0f;

    private float ballRadius;
    private Vector2 paddleHalfSize;

    private Vector3 lastPosition;
    public Vector2 mesuredVelocity;
    public float mesuredSpeed = 0f;

    private void Start()
    {
        ballRadius = GetComponent<SpriteRenderer>().bounds.extents.x;
        paddleHalfSize = paddle.GetComponent<SpriteRenderer>().bounds.extents;
        Launch();
    }

    void Update()
    {
        Move();
        CheckPaddleBounce();
        CheckWallBounce();
    }

    private void LateUpdate()
    {
        // Mesure Velocity and Speed
        mesuredVelocity = ((Vector2)(transform.position - lastPosition)) / Time.deltaTime;
        mesuredSpeed = Mathf.Round(mesuredVelocity.magnitude * 100f) / 100f;
        lastPosition = transform.position;
    }

    void Launch()
    {
        lastPosition = transform.position;

        float angle = Random.Range(-45f, 45f);
        float dirX = Random.value < 0.5f ? -1 : 1;

        velocity = new Vector2(
            dirX,
            Mathf.Sin(angle * Mathf.Deg2Rad)
        ).normalized * speed;

        saveSpeed = Mathf.Abs(velocity.y);
    }

    void Move()
    {
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }

    void CheckPaddleBounce()
    {
        if (velocity.x >= 0) return;

        Vector3 p = paddle.position;
        float paddleRightEdge = p.x + paddleHalfSize.x;

        bool hitX = transform.position.x - ballRadius <= paddleRightEdge;
        bool notPastPaddle = transform.position.x > p.x;
        bool hitY = Mathf.Abs(transform.position.y - p.y) <= paddleHalfSize.y + ballRadius;

        if (hitX && notPastPaddle && hitY)
        {
            velocity.x = Mathf.Abs(velocity.x);
            transform.position = new Vector3(paddleRightEdge + ballRadius, transform.position.y, 0f);
        }
    }

    void CheckWallBounce()
    {
        // Top / Bottom
        if (transform.position.y >= topBound && velocity.y > 0)
        {
            velocity.y = -saveSpeed * boost;
            transform.position = new Vector3(transform.position.x, topBound, 0);
        }
        
        if (transform.position.y <= bottomBound && velocity.y < 0)
        {
            velocity.y = saveSpeed;
            transform.position = new Vector3(transform.position.x, bottomBound, 0);
        }

        // Left / Right
        if (transform.position.x >= rightBound && velocity.x > 0)
        {
            velocity.x *= -1;
            transform.position = new Vector3(rightBound, transform.position.y, 0);
        }

        if (transform.position.x <= leftBound && velocity.x < 0)
        {
            velocity.x *= -1;
            transform.position = new Vector3(leftBound, transform.position.y, 0);
        }
    }
}