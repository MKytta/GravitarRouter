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
        LevelFinished
    }

    public States m_currentState = States.Launching;

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

    public void SetState(States state)
    {
        m_currentState = state;
        OnStateChange.Invoke();
    }

    public States GetState()
    {
        return m_currentState;
    }
}
