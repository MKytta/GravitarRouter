using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyerScript : MonoBehaviour
{
    public OutOfBoundsArrowScript m_arrow;
    public Animator m_animator;
    public AudioClip m_wallHit;
    public AudioClip m_BasicDeathSound;
    public GameObject m_deathParticles;

    private Vector2 m_movement = Vector2.zero;
    private bool m_launched = false;
    private bool m_outOfBounds = false;
    private float m_outOfBoundsTimer = 0;
    private float m_outOfBoundsTimeLimit = 3;

    private UnityAction OnDeath;
    private UnityAction OnWin;

    void Start()
    {
        
    }



    void Update()
    {
        if (m_launched == true)
        {
            transform.Translate(m_movement * Time.deltaTime, Space.World);
            transform.up = m_movement;

            if (m_outOfBounds == true)
            {
                m_outOfBoundsTimer += Time.deltaTime;
                if (m_outOfBoundsTimer > m_outOfBoundsTimeLimit)
                {
                    m_outOfBoundsTimer = 0;
                    Death();
                }
            }
        }
    }

    public void Initiate(UnityAction OnDeath, UnityAction OnWin)
    {
        this.OnDeath = OnDeath;
        this.OnWin = OnWin;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ColliderBounce")
        {
            m_movement = Vector2.Reflect(m_movement, collision.GetContact(0).normal);
            m_animator.Play("Hit");
            SoundManager.instance.PlaySound(m_wallHit);
        }
        if (collision.gameObject.tag == "Collectable")
        {
            m_animator.Play("Collect");
        }
        if (collision.gameObject.tag == "ColliderExit")
        {
            OnWin?.Invoke();
        }
        if (collision.gameObject.tag == "ColliderLethal")
        {
            SoundManager.instance.PlaySound(m_BasicDeathSound);
            Death();
        }
    }

    public void Launch(Vector2 launchSpeed, Vector3 launchPosition)
    {
        m_movement = launchSpeed;
        transform.position = launchPosition;
        m_launched = true;
    }

    public void ResetLaunch(LauncherScript launcher)
    {
        m_launched = false;
        m_outOfBounds = false;
        transform.position = launcher.transform.position;
        m_arrow.SetVisibility(false);
    }

    public void Death()
    {
        GameObject _particles = Instantiate(m_deathParticles);
        _particles.transform.position = transform.position;
        _particles.transform.rotation = transform.rotation;
        var _particleSpeed = _particles.GetComponent<ParticleSystem>().main;
        _particleSpeed.startSpeed = m_movement.magnitude;

        OnDeath.Invoke();
    }

    public void ApplyMovementForce(Vector2 force)
    {
        m_movement += force;
    }

    public bool IsFlying()
    {
        return m_launched;
    }

    public Vector2 GetSpeed()
    {
        return m_movement;
    }

    public void OnBecameVisible()
    {
        if (m_launched == true)
        {
            m_arrow.SetVisibility(false);
            m_outOfBounds = false;
            m_outOfBoundsTimer = 0;
        }
    }

    public void OnBecameInvisible()
    {
        if (m_launched == true)
        {
            m_arrow.SetVisibility(true);
            m_outOfBounds = true;
        }
    }
}
