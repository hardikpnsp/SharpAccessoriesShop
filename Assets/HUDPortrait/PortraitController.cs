using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitController : MonoBehaviour
{
    [SerializeField]
    public Sprite[] Portraits;

    public static PortraitController Instance;

    public Image Image;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            Image = GetComponent<Image>();
            ChangeMood(0);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeMood(int moodIndex)
    {
        if (moodIndex >= Portraits.Length)
        {
            Debug.LogError("Requested portrait doesn't exist");
        }
        Image.sprite = Portraits[moodIndex];
    }

}
