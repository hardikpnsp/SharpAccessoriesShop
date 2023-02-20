using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Customer : MonoBehaviour
{
    public void Spawn(Vector2 position)
    {
        transform.position = position;
    }

    public void Despawn()
    {
    }
}
