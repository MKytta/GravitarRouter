using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitarScript : MonoBehaviour
{
    private float m_gravityPower = 25;
    private float m_minClamp = 2.5f;
    private float m_maxClamp = 7;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActivePull(FlyerScript flyer)
    {
        Vector2 _distanceVector = transform.position - flyer.transform.position;
        Vector2 _directionNormalized = _distanceVector.normalized;
        float _distance = Mathf.Clamp(Mathf.Sqrt(_distanceVector.sqrMagnitude), m_minClamp, m_maxClamp);

        Vector2 _pullForce = _directionNormalized * (m_gravityPower / _distance) * Time.deltaTime;

        flyer.ApplyMovementForce(_pullForce);
    }
}
