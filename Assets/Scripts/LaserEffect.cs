using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffect : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer;

    private readonly float m_flickerSpeed = 5;
    private float m_alpha = 1;

    void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        m_alpha = 1 - ((Mathf.Cos(Mathf.Repeat(Time.time * m_flickerSpeed, Mathf.PI * 2)) + 1) / 3);
        Color _color = m_spriteRenderer.color;
        _color.a = m_alpha;
        m_spriteRenderer.color = _color;
    }
}
