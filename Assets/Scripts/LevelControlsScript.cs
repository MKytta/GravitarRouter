using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControlsScript : MonoBehaviour
{
    public FlyerScript m_flyer;
    public LauncherScript m_launcher;
    public GravitarManager m_gravitarManager;
    public LevelManager m_levelManager;

    private float m_launchTimer = 0;
    private float m_maxPowerTime = 1.5f;

    private bool m_startedLaunch = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && StateManager.instance.GetState() == StateManager.States.Launching)
        {
            m_startedLaunch = true;
            m_launcher.StartLaunching();
        }

        if (Input.GetButton("Fire1") && StateManager.instance.GetState() == StateManager.States.Launching && m_startedLaunch == true)
        {
            m_launchTimer += Time.deltaTime;
            m_launcher.SetPowerLevel((m_launchTimer / m_maxPowerTime) * 100f);
        }

        if (Input.GetButtonUp("Fire1") && m_launchTimer > 0)
        {
            float _fixedTimer = Mathf.Clamp(m_launchTimer - 0.1f, 0, m_maxPowerTime);
            m_launcher.LaunchFlyer(m_flyer, _fixedTimer, m_maxPowerTime);
            m_levelManager.FlyerLaunched();
            m_launchTimer = 0;
            m_startedLaunch = false;
            m_launcher.SetPowerLevel(0);
        }

        if (Input.GetButton("Fire1") && StateManager.instance.GetState() == StateManager.States.Flying)
        {
            m_gravitarManager.ActivateClosestGravitar();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (StateManager.instance.GetState() == StateManager.States.Flying)
            {
                m_levelManager.ResetLevel();
            }
            if (StateManager.instance.GetState() == StateManager.States.LevelFinished)
            {
                m_levelManager.RetryLevel();
            }
        }

        if (Input.GetButtonDown("Cancel") && StateManager.instance.GetState() != StateManager.States.Pause)
        {
            m_levelManager.PauseLevel();
        }
    }
}
