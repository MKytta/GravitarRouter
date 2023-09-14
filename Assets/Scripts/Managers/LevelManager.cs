using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public FlyerScript m_flyer;
    public LauncherScript m_launcher;
    public CollectablesManager m_collectablesManager;
    public GravitarManager m_gravitarManager;
    public UiManager m_uiManager;
    //public LevelGenerator m_levelGenerator;
    public GameObject m_flyerDummy;

    public AudioClip m_levelMusic;

    public event UnityAction OnDeath;
    public event UnityAction OnWin;

    void Start()
    {
        OnDeath = ResetLevel;
        OnWin = WinLevel;
        StateManager.instance.ResetState();
        StateManager.instance.OnStateChange += VictoryScreen;
        m_flyer.Initiate(OnDeath, OnWin);

        SoundManager.instance.LevelStartPlayMusic(m_levelMusic);
    }

    void Update()
    {
        
    }

    public void WinLevel()
    {
        m_gravitarManager.FlyerFlying(false);
        StartEndAnimation();
        StateManager.instance.SetState(StateManager.States.LevelFinished);
    }

    public void ResetLevel()
    {
        m_flyer.gameObject.SetActive(true);
        m_flyer.ResetLaunch(m_launcher);
        m_launcher.ResetLaunch();
        m_collectablesManager.ResetCollectables();
        m_gravitarManager.FlyerFlying(false);
        StateManager.instance.SetState(StateManager.States.Launching);
        CancelInvoke();
    }

    public void RetryLevel()
    {
        ResetLevel();
    }

    public void NextLevel()
    {
        StateManager.instance.SetState(StateManager.States.Launching);
        LevelSelectionManager.instance.AdvanceLevel();
    }

    public void PauseLevel()
    {
        m_uiManager.CreatePauseMenu();
    }

    public void FlyerLaunched()
    {
        StateManager.instance.SetState(StateManager.States.Flying);
        m_gravitarManager.FlyerFlying(true);
    }

    public void VictoryScreen()
    {
        if (StateManager.instance.GetState() == StateManager.States.LevelFinished)
        {
            m_uiManager.LevelCompleted(m_collectablesManager.GetCollectedStars(), m_collectablesManager.GetMaxStars());
        }
    }

    private void StartEndAnimation()
    {
        var _dummy = Instantiate(m_flyerDummy);
        _dummy.transform.position = m_flyer.transform.position;
        _dummy.transform.rotation = m_flyer.transform.rotation;
        _dummy.GetComponent<DummyFlyer>().Initiate(m_flyer.GetSpeed());
        m_flyer.gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        StateManager.instance.OnStateChange -= VictoryScreen;
    }
}
