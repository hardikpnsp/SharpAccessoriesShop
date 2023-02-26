using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioSource audioSource;
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void OnValueChanged()
    {
        audioSource.volume = slider.value;
    }
}
