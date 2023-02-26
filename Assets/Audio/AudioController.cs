using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public AudioSource MusicSource;
    public AudioSource EffectSource;
    public AudioClip backgroundMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            EffectSource.loop = false;
            
            MusicSource.clip = backgroundMusic;
            MusicSource.loop = true;
            PlayMusic();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PauseMusic()
    {
        MusicSource.Pause();
    }

    public void PlayMusic()
    {
        MusicSource.Play();
    }

    public void PlayEffect(AudioClip effect)
    {
        EffectSource.clip = effect;
        EffectSource.Play();
    }

    // volume is set beween 0 and 1
    public void MusicVolumeUp()
    {
        MusicSource.volume += 0.1f;
    }    
    
    public void MusicVolumeDown()
    {
        MusicSource.volume -= 0.1f;
    }

    public void SetMusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }    
    
    public void EffectVolumeUp()
    {
        EffectSource.volume += 0.1f;
    }    
    
    public void EffectVolumeDown()
    {
        EffectSource.volume -= 0.1f;
    }

    public void SetEffectVolume(float volume)
    {
        EffectSource.volume = volume;
    }
}
