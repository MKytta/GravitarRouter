using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    public GameObject m_cannon;
    public List<LauncherPowerIndicator> m_indicators = new List<LauncherPowerIndicator>();
    public AudioClip m_launchSound;
    public AudioClip m_continuousLaunchingSound;

    private bool m_launched = false;
    private float m_launchPower = 1;
    private float m_powerLevel = 0;
    private float m_maxPowerLevel = 100;

    void Start()
    {
        
    }

    void Update()
    {
        if (StateManager.instance.GetState() == StateManager.States.Launching)
        {
            Vector2 _direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            m_cannon.transform.up = _direction;
        }
    }

    public void StartLaunching()
    {
        SoundManager.instance.PlayContinuousSound(m_continuousLaunchingSound);
    }

    public void LaunchFlyer(FlyerScript flyer, float launchTime, float maxTime)
    {
        if (m_launched == false)
        {
            m_launched = true;
            Vector2 _launchVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Vector2 _launchDirection = _launchVector.normalized;
            //float _launchSpeed = Mathf.Clamp(Mathf.Sqrt(_launchVector.sqrMagnitude), 2f, 8f); old way

            float _launchSpeed = 2 + (launchTime / maxTime) * 6;

            flyer.Launch(_launchDirection * _launchSpeed * m_launchPower, transform.position);

            SoundManager.instance.StopContinuousSound();
            SoundManager.instance.PlaySound(m_launchSound);
        }
    }

    public void ResetLaunch()
    {
        m_launched = false;
    }

    public bool IsLaunched()
    {
        return m_launched;
    }

    public void SetPowerLevel(float powerLevel)
    {
        float _clampedPowerLevel = Mathf.Clamp(powerLevel, 0, m_maxPowerLevel);

        if (powerLevel > 0)
        {
            SoundManager.instance.SetContinuousSoundPitch(0.45f + (_clampedPowerLevel / 60));
        }

        m_powerLevel = _clampedPowerLevel;
        for (int i = 0; i < m_indicators.Count; i++)
        {
            m_indicators[i].CurrentPower(m_powerLevel);
        }
    }
}
