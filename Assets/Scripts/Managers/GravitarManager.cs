using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GravitarManager : MonoBehaviour
{
    public List<GravitarScript> m_gravitars = new List<GravitarScript>();
    public FlyerScript m_flyer;
    public ClosestGravitarEffect m_closestEffect;

    private GravitarScript m_closestGravitar;

    void Start()
    {
        GameObject _gravitarParent = GameObject.FindGameObjectWithTag("GravitarParent");

        m_gravitars.AddRange(_gravitarParent.GetComponentsInChildren<GravitarScript>());
    }

    void Update()
    {
        if (m_gravitars.Count > 0)
        {
            m_closestGravitar = m_gravitars.Where(n => n).OrderBy(n => (n.transform.position - m_flyer.transform.position).sqrMagnitude).FirstOrDefault();
            m_closestEffect.ShowActive(m_closestGravitar);
        }
    }

    public void ActivateClosestGravitar()
    {
        if (m_gravitars.Count > 0)
        {
            m_closestGravitar.ActivePull(m_flyer);
            m_closestEffect.ShowPullLine(m_flyer);
        }
    }

    public void FlyerFlying(bool flying)
    {
        m_closestEffect.ToggleVisibility(flying);
    }
}
