using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollectable : MonoBehaviour
{
    private CollectablesManager m_collectablesManager;

    private Vector3 m_startPosition;
    private Vector3 m_endPosition;
    private float m_time = 3f;
    private float m_screenSizeModifier = 1;

    private float m_speed = -350f;
    private float m_acceleration = 0.5f;
    private float m_screenSizeTarget = 1600;


    private RectTransform m_rectTransform;
    

    private IEnumerator m_animationRoutine;

    void Start()
    {
        
    }

    private void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
        float _clampedWidth = Mathf.Clamp(Screen.width, 200, Mathf.Infinity);
        m_screenSizeModifier =  m_screenSizeTarget / _clampedWidth;

        StateManager.instance.OnStateChange += StateCheck;
    }

    void Update()
    {
        
    }

    public void Initiate(CollectablesManager manager, Vector3 startPosition, Vector3 endPosition)
    {
        m_collectablesManager = manager;
        m_rectTransform.localPosition = startPosition;
        m_startPosition = startPosition;
        m_endPosition = endPosition;

        m_animationRoutine = FlyToScore();
        StartCoroutine(m_animationRoutine);

    }

    public void StateCheck()
    {
        if (StateManager.instance.GetState() == StateManager.States.Launching)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator FlyToScore()
    {
        while (m_rectTransform.localPosition != m_endPosition)
        {

            m_time += Time.deltaTime;
            m_speed += m_acceleration * Mathf.Pow(m_time, 2) * m_screenSizeModifier;

            m_rectTransform.localPosition = Vector3.MoveTowards(m_rectTransform.localPosition, m_endPosition, m_speed * Time.deltaTime);

            yield return null;
        }

        m_collectablesManager.VisualScoreCollected();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StateManager.instance.OnStateChange -= StateCheck;
    }
}
