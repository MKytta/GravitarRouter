using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollectable : MonoBehaviour
{
    private CollectablesManager m_collectablesManager;

    private Vector3 m_startPosition;
    private Vector3 m_endPosition;
    private float m_duration = 0.5f;

    private float m_xVelocity = 0;
    private float m_yVelocity = 0;
    

    private IEnumerator m_animationRoutine;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Initiate(CollectablesManager manager, Vector3 startPosition, Vector3 endPosition)
    {
        m_collectablesManager = manager;
        transform.position = startPosition;
        m_startPosition = startPosition;
        m_endPosition = endPosition;

        m_animationRoutine = FlyToScore();
        StartCoroutine(m_animationRoutine);
    }

    public IEnumerator FlyToScore()
    {
        float currX = Mathf.SmoothStep(m_startPosition.x, m_endPosition.x, 1);
        float currY = Mathf.SmoothStep(m_startPosition.y, m_endPosition.y, 1);
        yield return null;
    }

    private float ExponentialSpeed()
    {
        return 0;
    }
}
