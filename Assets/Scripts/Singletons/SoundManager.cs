using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource m_effectAudioPlayer;
    public AudioSource m_continuousEffectAudioPlayer;
    public AudioSource m_musicAudioPlayer;

    private string m_currentSong = "";

    private void Awake()
    {
        //m_effectAudioPlayer = GetComponent<AudioSource>();
        //m_musicAudioPlayer = GetComponentInChildren<AudioSource>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void SetMusicVolume(float volume)
    {
        float _adjustedVolume = Mathf.Clamp(volume, 0, 10);
        _adjustedVolume = Mathf.Pow(_adjustedVolume, 2);
        _adjustedVolume /= 100;
        
        m_musicAudioPlayer.volume = _adjustedVolume;
    }

    public float GetMusicVolume()
    {
        return m_musicAudioPlayer.volume;
    }

    public void SetEffectVolume(float volume)
    {
        float _adjustedVolume = Mathf.Clamp(volume, 0, 10);
        _adjustedVolume = Mathf.Pow(_adjustedVolume, 2);
        _adjustedVolume /= 100;

        m_effectAudioPlayer.volume = _adjustedVolume;
        m_continuousEffectAudioPlayer.volume = _adjustedVolume;
    }

    public float GetEffectVolume()
    {
        return m_effectAudioPlayer.volume;
    }

    public void LevelStartPlayMusic(AudioClip music)
    {
        if (m_currentSong != music.name)
        {
            SetMusic(music);
            PlayMusic();
        }
    }

    public void PlaySound(AudioClip sound)
    {
        if (sound != null)
        {
            m_effectAudioPlayer.PlayOneShot(sound);
        }
        else
        {
            Debug.LogWarning("Tried to play null sound effect.");
        }
    }

    public void PlayContinuousSound(AudioClip sound)
    {

        if (sound != null)
        {
            StopContinuousSound();
            m_continuousEffectAudioPlayer.clip = sound;
            m_continuousEffectAudioPlayer.Play();
        }
        else
        {
            Debug.LogWarning("Tried to play null continuous sound effect.");
        }
    }

    public void StopContinuousSound()
    {
        if (m_continuousEffectAudioPlayer.isPlaying)
        {
            m_continuousEffectAudioPlayer.Stop();
            m_continuousEffectAudioPlayer.pitch = 1f;
        }
    }

    public void SetContinuousSoundPitch(float pitch)
    {
        m_continuousEffectAudioPlayer.pitch = pitch;
    }

    public void SetMusic(AudioClip music)
    {
        m_currentSong = music.name;
        m_musicAudioPlayer.clip = music;
    }

    public void PlayMusic()
    {
        m_musicAudioPlayer.Play();
    }

    public void StopMusic()
    {
        m_musicAudioPlayer.Stop();
    }

    public string CurrentSong()
    {
        return m_currentSong;
    }
}
