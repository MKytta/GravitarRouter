using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource m_effectAudioPlayer;
    public AudioSource m_musicAudioPlayer;

    private string m_currentSong = "";

    private void Awake()
    {
        //m_effectAudioPlayer = GetComponent<AudioSource>();
        //m_musicAudioPlayer = GetComponentInChildren<AudioSource>();

        m_musicAudioPlayer.loop = true;
        SetMusicVolume(0.1f);

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
        //TODO: Figure out logarithmic formula for sound
        float _adjustedVolume = Mathf.Clamp(volume, 0, 1);
        //m_musicAudioPlayer.volume = Mathf.Sqrt(_adjustedVolume);
        m_musicAudioPlayer.volume = volume;
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
        m_effectAudioPlayer.PlayOneShot(sound);
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
