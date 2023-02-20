using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Utils
{
    public static IEnumerable<T> Shuffle<T>(IEnumerable<T> enumerableObject)
    {
        T[] array = enumerableObject.ToArray();
        int size = array.Length;

        for (int i = 0; i < size - 1; i++)
        {
            int randomIndex = Random.Range(i, size);
            T buffer = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = buffer;
        }

        return array;
    }
}
