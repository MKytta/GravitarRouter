using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyFlyer : MonoBehaviour
{
    private GameObject m_wormhole;
    private Vector2 m_wormholePosition;
    private Vector2 m_speed;
    private Vector3 m_previousPosition;
    private float m_timer = 0;
    private float m_speedDot;
    private float m_startingDistance = 1;


    void Start()
    {
        m_wormhole = GameObject.FindGameObjectWithTag("ColliderExit");
        m_wormholePosition = new Vector2(m_wormhole.transform.position.x, m_wormhole.transform.position.y);
        m_startingDistance = Vector2.Distance(transform.position, m_wormhole.transform.position);
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        transform.up = transform.position - m_previousPosition;
        m_previousPosition = transform.position;

        m_speedDot = Vector2.Dot((m_wormhole.transform.position - transform.position).normalized, m_speed.normalized);

        Vector2 _distanceVector = m_wormhole.transform.position - transform.position;
        Vector2 _directionNormalized = _distanceVector.normalized;

        Vector2 _pullForce = _directionNormalized * 20 * Time.deltaTime;
        _pullForce = _pullForce * (1 - m_speedDot * 5);

        m_speed += _pullForce;

        transform.Translate(m_speed * Time.deltaTime, Space.World);
        transform.position = Vector2.MoveTowards(transform.position, m_wormhole.transform.position, m_startingDistance * Time.deltaTime);

        float _dist = Vector2.Distance(transform.position, m_wormhole.transform.position);
        float _disappearanceScale = Mathf.Clamp01(_dist / m_startingDistance);

        transform.localScale = new Vector3(_disappearanceScale, _disappearanceScale, 1);

        if (m_timer > 3 || transform.position == m_wormhole.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public void Initiate(Vector2 initialSpeed)
    {
        m_speed = initialSpeed;

        m_previousPosition = transform.position - new Vector3(initialSpeed.x, initialSpeed.y);

    }
}
