using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.BehaviourTrees;

[RequireComponent(typeof(BehaviourTreeOwner))]
public class Customer : MonoBehaviour
{
    private BehaviourTreeOwner _btOwner;
    private Vector2 _spawnPoint;

    private void Awake()
    {
        _btOwner = GetComponent<BehaviourTreeOwner>();
        _btOwner.StopBehaviour();
    }

    public void Spawn(Vector2 position)
    {
        _spawnPoint = position;
        transform.position = _spawnPoint;
        _btOwner.StartBehaviour();
    }

    public void Despawn()
    {
    }
}
