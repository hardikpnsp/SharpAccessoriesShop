using System;
using UnityEngine;

// to figure out left-right direction for sprite
enum Direction
{
    Left,
    Right
}

// to figure out movement anmation for the sprite
enum MovementState
{
    Moving,
    Idle
}

public class Movement : MonoBehaviour
{

    Direction direction = Direction.Right;
    MovementState movementState = MovementState.Idle;

    [SerializeField]
    public float speed = 2.0f;

    [SerializeField]
    private RuntimeAnimatorController IdleAnimationController;    
    
    [SerializeField]
    private RuntimeAnimatorController MovingAnimationController;


    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;

    private float verticalInput;
    private float horizontalInput;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();

        verticalInput = 0.0f;
        horizontalInput = 0.0f;
    }

    void Update()
    {
        checkInput();

        updateDirection();
        updateMovement();

        updateSpriteDirecton();
        updateAnimation();
        move();
    }

    private void updateAnimation()
    {
        if (movementState == MovementState.Idle)
        {
            Animator.runtimeAnimatorController = IdleAnimationController;
        } else if (movementState == MovementState.Moving)
        {
            Animator.runtimeAnimatorController = MovingAnimationController;
        }
    }

    private void checkInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void updateSpriteDirecton()
    {
        switch (direction) {
            case Direction.Left:
                SpriteRenderer.flipX = true;
                return;
            case Direction.Right:
                SpriteRenderer.flipX = false;
                return;
        }
    }

    private void move()
    {
        Rigidbody2D.velocity = (new Vector2(horizontalInput, verticalInput) * speed);
    }

    private void updateMovement()
    {
        if (horizontalInput != 0 || verticalInput != 0)
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
        if (horizontalInput > 0)
        {
            direction = Direction.Right;
        }
        else if (horizontalInput < 0)
        {
            direction = Direction.Left;
        }
    }
}
