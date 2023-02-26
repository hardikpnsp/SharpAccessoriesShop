using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitController : MonoBehaviour
{
    [SerializeField]
    public Sprite[] Portraits;

    public static PortraitController Instance;

    public int lowMood_max;
    public int normalMood_max;
    public int goodMood_max;

    public Image Image;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            Image = GetComponent<Image>();
        }
        else
        {
            Destroy(this);
        }

        ConfidenceController.ConfidenceChanged += ConfidenceController_ConfidenceChanged;
        ConfidenceController_ConfidenceChanged(ConfidenceController.Confidence);
    }

    private void ConfidenceController_ConfidenceChanged(int arg0)
    {
        if(arg0 <= lowMood_max)
        {
            ChangeMood(0);
        }
        else
        {
            if (arg0 <= normalMood_max)
            {
                ChangeMood(1);
            }
            else
            {
                if (arg0 <= goodMood_max)
                {
                    ChangeMood(2);
                }
            }
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
