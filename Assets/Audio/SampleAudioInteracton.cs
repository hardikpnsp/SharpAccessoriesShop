using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAudioInteracton : MonoBehaviour
{
    public AudioClip confidenceUp;
    public AudioClip confidenceDown;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioController.Instance.PlayEffect(confidenceUp);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioController.Instance.PlayEffect(confidenceUp);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioController.Instance.MusicVolumeUp();
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            AudioController.Instance.MusicVolumeDown();
        }
    }
}
