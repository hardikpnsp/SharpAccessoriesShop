using UnityEngine;

enum Direction
{
    Up,
    Down,
    Left,
    Right
}

enum MovementState
{
    Moving,
    Idle
}

public class Movement : MonoBehaviour
{

    Direction direction = Direction.Up;
    MovementState movementState = MovementState.Idle;

    [SerializeField]
    public float speed = 2.0f;

    void Update()
    {
        updateDirection();
        updateMovement();

        move();
    }

    private Vector3 getDirectionVector()
    {
        switch (this.direction)
        {
            case Direction.Up:
                return new Vector3(0, 0, 1);
            case Direction.Down:
                return new Vector3(0, 0, -1);
            case Direction.Left:
                return new Vector3(-1, 0, 0);
            case Direction.Right:
                return new Vector3(1, 0, 0);
            default:
                return new Vector3(0, 0, 0);
        }
    }

    private void move()
    {
        if (this.movementState == MovementState.Moving)
        {
            Vector3 direction = getDirectionVector();
            Vector3 moveStep = direction * speed * Time.deltaTime;
            this.transform.position += moveStep;
        }
    }

    private void updateMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            movementState = MovementState.Moving;
        }
        else 
        {
            movementState = MovementState.Idle;       
        }
    }

    private void updateDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = Direction.Up;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = Direction.Left;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Direction.Down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Direction.Right;
        }
    }
}
