using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;



public class CustomerMovement : MonoBehaviour
{
    public UnityEvent OnDestinatonReached;

    private NavMeshAgent agent;
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;

    private MovementState customerMovementState = MovementState.Idle;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        checkDirectionAndFlip();
        checkMovement();
    }

    private void checkMovement() {
        // Have to do an exhaustive check because NavMeshAgent doesn't have a callback when destination is reached 
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && agent.velocity.sqrMagnitude == 0 && customerMovementState == MovementState.Moving)
        {
            Animator.SetBool("Moving", false);
            customerMovementState = MovementState.Idle;

            // Callback
            OnDestinatonReached.Invoke();
        }
    }

    private void checkDirectionAndFlip()
    {
        if (agent.velocity.x > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if (agent.velocity.x < 0)
        {
            SpriteRenderer.flipX = true;
        }
    }

    public void Move(Transform goal)
    {
        customerMovementState = MovementState.Moving;
        Animator.SetBool("Moving", true);

        agent.destination = goal.position;
    }
}
