using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsArrowScript : MonoBehaviour
{
    public FlyerScript m_flyer;
    public SpriteRenderer m_sprite;

    private bool m_visible = false;
    private float m_timer = 0; 

    void Start()
    {
        
    }

    void Update()
    {
        if (m_visible)
        {
            float _posX = Mathf.Clamp(m_flyer.transform.position.x, -8.4f, 8.4f);
            float _posY = Mathf.Clamp(m_flyer.transform.position.y, -4.5f, 4.5f);
            transform.position = new Vector3(_posX, _posY);
            transform.up = m_flyer.transform.position - transform.position;

            m_timer += Time.deltaTime;
            m_sprite.color = Color.Lerp(Color.white, Color.red, m_timer / 2.5f);
        }
    }

    public void SetVisibility(bool visible)
    {
        m_timer = 0;
        m_visible = visible;
        m_sprite.enabled = visible;
    }
}
