using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatienceUI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    public void SetFill(float fill)
    {
        image.fillAmount = fill;
    }

}
