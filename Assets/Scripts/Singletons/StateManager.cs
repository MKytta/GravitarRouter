using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;

    public UnityAction OnStateChange;

    public enum States
    {
        Launching,
        Flying,
        LevelFinished,
        Pause
    }

    public States m_currentState = States.Launching;
    private States m_previousState = States.Launching;

    private void Awake()
    {
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

    public void ResetState()
    {
        m_previousState = States.Launching;
        m_currentState = States.Launching;
    }

    public void SetState(States state)
    {
        m_previousState = m_currentState;
        m_currentState = state;
        OnStateChange.Invoke();
    }

    public void ResumePreviousState()
    {
        SetState(m_previousState);
    }

    public States GetState()
    {
        return m_currentState;
    }

    public States GetPreviousState()
    {
        return m_previousState;
    }
}
