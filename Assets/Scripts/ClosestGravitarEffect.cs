using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestGravitarEffect : MonoBehaviour
{
    public LineRenderer m_line;
    public SpriteRenderer m_rendeder;

    private bool m_pullIsOn = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (m_pullIsOn == false)
        {
            m_line.enabled = false;
        }
        else
        {
            m_line.enabled = true;
        }

        m_pullIsOn = false;
    }

    public void ShowActive(GravitarScript gravitar)
    {
        transform.position = gravitar.transform.position;
        m_line.SetPosition(0, gravitar.transform.position);
    }

    public void ShowPullLine(FlyerScript flyer)
    {
        m_line.SetPosition(1, flyer.transform.position);
        m_pullIsOn = true;
    }

    public void ToggleVisibility(bool visibility)
    {
        m_rendeder.enabled = visibility;
    }

}
