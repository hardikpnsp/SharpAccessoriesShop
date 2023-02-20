using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerRole", menuName = "CustomerRole", order = 51)]
public class CustomerRole : ScriptableObject
{
    [SerializeField] private Customer _prefab;

    public Customer Prefab => _prefab;
}