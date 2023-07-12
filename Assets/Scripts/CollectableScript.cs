using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableScript : MonoBehaviour
{
    public GameObject m_graphic;

    private float m_spinSpeed = 120;
    private bool m_collected = false;

    private UnityAction OnCollection;

    void Start()
    {
        m_graphic.transform.Rotate(0, 0, Random.Range(0,359));
    }

    void Update()
    {
        if (m_collected == false)
        {
            m_graphic.transform.Rotate(0, 0, m_spinSpeed * Time.deltaTime);
        }
    }

    public void Initiate(UnityAction OnCollection)
    {
        this. OnCollection = OnCollection;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_collected == false)
        {
            Collected();
            OnCollection.Invoke();
        }
    }

    public void Collected()
    {
        m_collected = true;
        m_graphic.SetActive(false);
    }

    public void ResetCollectible()
    {
        m_collected = false;
        m_graphic.SetActive(true);
    }
}
