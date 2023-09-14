using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaRandomizer : MonoBehaviour
{
    public float m_maxX = 10;
    public float m_minX = -10;
    public float m_maxY = 12;
    public float m_minY = -12;

    void Start()
    {
        float _randomX = Random.Range(m_minX, m_maxX);
        float _randomY = Random.Range(m_minY, m_maxY);
        float _randomRotation = Random.Range(0, 360);

        transform.position = new Vector3(_randomX, _randomY, 0);
        transform.Rotate(new Vector3(0, 0, _randomRotation));
    }

    void Update()
    {
        
    }
}
