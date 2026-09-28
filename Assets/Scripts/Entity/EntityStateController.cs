using UnityEngine;

public class EntityStateController : MonoBehaviour
{
    private float timer = 0f;
    private int state = 0;

    private EntityMovement mover;

    void Start()
    {
        mover = GetComponent<EntityMovement>();
        mover.SetDirection(Vector3.right);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3f)
        {
            timer = 0f;
            state++;

            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (state % 2 == 0)
        {
            mover.SetDirection(Vector3.up);
        }
        else if (state % 3 == 0)
        {
            mover.SetDirection(Vector3.zero);
        }
        else
        {
            mover.SetDirection(Vector3.right);
        }
    }
}