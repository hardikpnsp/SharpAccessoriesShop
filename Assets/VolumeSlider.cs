using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private  AudioSource audioSource;
    private Slider slider;

    public bool isMusic;

    private void Start()
    {
        slider = GetComponent<Slider>();

        if (isMusic)
        {
            audioSource = AudioController.Instance.MusicSource;
        }
        else
        {
            audioSource = AudioController.Instance.EffectSource;
        }
    }

    public void OnValueChanged()
    {
        audioSource.volume = slider.value;
    }
}
