using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class Paddle : MonoBehaviour
{
    public float speed = 8f;

    public float topMax = 4.5f;
    public float bottomMax = -4.5f;
    public float setLeft = -10f;

    private Vector2 velocity;
    void Start()
    {
        Launch();
    }

    void Update()
    {
        Move();
    }

    void Launch()
    {
        float varticalPosition = Random.Range(topMax, bottomMax);
        transform.position = new Vector2(setLeft, varticalPosition);
    }

    void Move()
    {
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W)) vertical += 1f;
        if (Input.GetKey(KeyCode.S)) vertical -= 1f;

        velocity = new Vector2(0f, vertical * speed);
        transform.position += (Vector3)(velocity * Time.deltaTime);
        
        //Clamping position max vertical
        float y = Mathf.Clamp(transform.position.y, bottomMax, topMax);
        transform.position = new Vector3(transform.position.x, y, 0f);
    }
}
