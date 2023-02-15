using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementTest : MonoBehaviour
{
    public float speed;

    public float forceValue;

    private Rigidbody2D Rigidbody2D;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Rigidbody2D.velocity = (new Vector2(horizontal, vertical) * speed);
    }

    float vertical;
    float horizontal;

    private void FixedUpdate()
    {
        // gameObject.transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.fixedDeltaTime);
        

    }
}
