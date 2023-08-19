using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePulse : MonoBehaviour
{
    public Transform m_targetTransform;
    public RectTransform m_targetRectTransform;

    public Vector3 m_pulseAmount = Vector3.one;
    public float m_pulseRecoveryTime = 0.5f;

    private Vector3 m_baseTransformScale = Vector3.one;
    private Vector3 m_baseRectTransformScale = Vector3.one;

    private Coroutine m_currentRoutine;

    void Start()
    {
        if (m_targetTransform != null)
        {
            m_baseTransformScale = m_targetTransform.localScale;
        }
        if (m_targetRectTransform != null)
        {
            m_baseRectTransformScale = m_targetRectTransform.localScale;
        }
    }

    void Update()
    {

    }

    public void ActivatePulse()
    {
        if (m_currentRoutine != null)
        {
            StopCoroutine(m_currentRoutine);
        }
        m_currentRoutine = StartCoroutine(Pulse());
    }

    private IEnumerator Pulse()
    {
        if (m_targetTransform != null)
        {
            m_targetTransform.localScale = m_baseTransformScale + m_pulseAmount;
        }

        if (m_targetRectTransform != null)
        {
            m_targetRectTransform.localScale = m_baseRectTransformScale + m_pulseAmount;
        }

        float _time = m_pulseRecoveryTime;

        while (_time > 0)
        {
            _time -= Time.deltaTime;

            if (m_targetTransform != null)
            {
                m_targetTransform.localScale = Vector3.Lerp(m_baseTransformScale, m_baseTransformScale + m_pulseAmount, _time / m_pulseRecoveryTime);
            }
            if (m_targetRectTransform != null)
            {
                m_targetRectTransform.localScale = Vector3.Lerp(m_baseRectTransformScale, m_baseRectTransformScale + m_pulseAmount, _time / m_pulseRecoveryTime);
            }


            yield return null;
        }

    }
}
