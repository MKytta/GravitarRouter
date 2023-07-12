using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour
{
    public float m_scrollSpeedX = 0.3f;
    public float m_scrollSpeedY = 0.3f;

    private Renderer m_renderer = null;

    void Start()
    {
        m_renderer = GetComponent<SpriteRenderer>();
        if (m_renderer == null)
        {
            m_renderer = GetComponent<LineRenderer>();
        }
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * m_scrollSpeedX, 1);
        float y = Mathf.Repeat(Time.time * m_scrollSpeedY, 1);
        Vector2 offset = new Vector2(x, y);
        m_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
