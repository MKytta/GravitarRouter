using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    public Slider m_musicSlider;
    public Slider m_effectSlider;
    public AudioClip m_testEffect;

    // Start is called before the first frame update
    void Start()
    {
        m_musicSlider.value = Mathf.Sqrt(SoundManager.instance.GetMusicVolume() * 100);
        m_effectSlider.value = Mathf.Sqrt(SoundManager.instance.GetEffectVolume() * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicVolumeChange(float change)
    {
        SoundManager.instance.SetMusicVolume(change);
    }

    public void EffectVolumeChange(float change)
    {
        SoundManager.instance.SetEffectVolume(change);
    }

    public void PlaySampleEffect()
    {
        SoundManager.instance.PlaySound(m_testEffect);
    }
}
