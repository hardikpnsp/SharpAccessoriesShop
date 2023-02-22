using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CustomersDistribution : MonoBehaviour
{
    [SerializeField] private List<CustomersDistributionItem> _items;

    private void OnValidate()
    {
        float sumLimit = 1;
        float sum = _items.Sum(item => item.Probability);

        if (sum != sumLimit && sum != 0)
        {
            foreach (CustomersDistributionItem item in _items)
            {
                item.SetProbability(item.Probability / sum);
            }
        }
    }
    
    public Stack<Customer> GenerateDistribution(int count)
    {
        if (count <= 0)
            throw new ArgumentException("You cannot generate distribution with non-positive amount of entries.");

        int itemCount;

        List<Customer> roles = new List<Customer>();

        foreach(CustomersDistributionItem item in _items)
        {
            itemCount = Mathf.CeilToInt(count * item.Probability);

            for (int i = 0; i < itemCount; i++)
                roles.Add(item.Value);
        }

        return new Stack<Customer>(Utils.Shuffle(roles).Take(count));
    }

    [Serializable]
    private class CustomersDistributionItem
    {
        [SerializeField] private Customer _value;
        [SerializeField, Range(0, 100)] private int _probabilityPercentage;

        public float Probability => _probabilityPercentage / 100.0f;
        public Customer Value => _value;

        public void SetProbability(float probability)
        {
            _probabilityPercentage = Mathf.RoundToInt(probability * 100);
        }
    }
}