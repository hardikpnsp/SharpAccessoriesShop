using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovement : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move(goal);
        }
    }

    private void checkMovement()
    {
        if (agent.velocity.magnitude > 0)
        {
            Animator.SetBool("Moving", true);
        }
        else
        {
            Animator.SetBool("Moving", false);
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
        agent.destination = goal.position;
    }
}
