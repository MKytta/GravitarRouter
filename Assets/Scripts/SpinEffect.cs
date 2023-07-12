using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinEffect : MonoBehaviour
{

    public float m_spinSpeed = 120;
    public bool m_randomStart = true;

    void Start()
    {
        if (m_randomStart == true)
        { 
            transform.Rotate(0, 0, Random.Range(0, 359));
        }
    }


    void Update()
    {
        transform.Rotate(0, 0, m_spinSpeed * Time.deltaTime);
    }
}
