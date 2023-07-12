using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherPowerIndicator : MonoBehaviour
{
    public float m_powerLimit = 1;
    public Color m_color = Color.green;

    private Color m_baseColor = new Color(0.4f, 0.4f, 0.4f);
    private SpriteRenderer m_renderer;

    void Start()
    {
        m_renderer = GetComponent<SpriteRenderer>();
        m_renderer.color = m_baseColor;
    }

    void Update()
    {
        
    }

    public void CurrentPower(float power)
    {
        if (power > m_powerLimit)
        {
            m_renderer.color = m_color;
        }
        else
        {
            m_renderer.color = m_baseColor;
        }
    }
}
