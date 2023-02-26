using System.Collections;
using UnityEngine;

namespace Assets.Audio
{
    public class PlayAudio : MonoBehaviour
    {
        [SerializeField]
        AudioClip AudioToPlay;

        public void Play()
        {
            AudioController.Instance.PlayEffect(AudioToPlay);
        }
    }
}