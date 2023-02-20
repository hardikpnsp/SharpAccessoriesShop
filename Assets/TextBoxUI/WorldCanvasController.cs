using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasController : MonoBehaviour
{
    public static WorldCanvasController Instance { get; private set; }

    [SerializeField]
    private Canvas worldCanvas;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    public GameObject InstantiateToWorldCanvas(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        return Instantiate(gameObject, position, rotation, worldCanvas.transform);
    }

    public GameObject InstantiateToWorldCanvas(GameObject gameObject, Vector3 position)
    {
        return Instantiate(gameObject, position, Quaternion.Euler(0,0,0), worldCanvas.transform);
    }

}
