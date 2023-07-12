using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletePanel : MonoBehaviour
{
    public TMPro.TMP_Text m_text;

    private int m_collectedStars = 0;
    private int m_maxStars = 1;
    private int m_starCounter = 0;
    private IEnumerator m_appearRoutine;

    private float m_appearTime = 0.6f;
    private float m_starCountTime = 1f;

    private LevelManager m_levelManager;

    void Start()
    {
        StateManager.instance.OnStateChange += StateChange;
    }

    void Update()
    {
        
    }

    public void RetryButton()
    {
        m_levelManager.RetryLevel();
    }

    public void NextButton()
    {
        m_levelManager.NextLevel();
    }

    public void Initiate(LevelManager levelManager, int collectedStars, int maxStars)
    {
        m_levelManager = levelManager;

        m_collectedStars = collectedStars;
        m_maxStars = maxStars;

        transform.localScale = Vector3.zero;
        m_text.text = $"0 / {m_maxStars}";

        m_appearRoutine = AnimationStack();
        StartCoroutine(m_appearRoutine);
    }

    public void StateChange()
    {
        StateManager.instance.OnStateChange -= StateChange;
        Destroy(gameObject);
    }

    public IEnumerator AnimationStack()
    {
        yield return StartCoroutine(AppearAnimation());
        yield return StartCoroutine(CountStars());
        if (m_collectedStars == m_maxStars)
        {
            yield return StartCoroutine(AllCollected());
        }
    }

    public IEnumerator AppearAnimation()
    {
        float _timer = 0;

        while (_timer <= m_appearTime)
        {
            _timer += Time.deltaTime;
            transform.localScale = Vector3.Slerp(Vector3.zero, Vector3.one, _timer / m_appearTime);
            yield return null;
        }

        transform.localScale = Vector3.one;

    }

    public IEnumerator CountStars()
    {
        float _timer = 0;

        if (m_collectedStars == 0)
        {
            yield break;
        }

        float _betweenStars = m_starCountTime / m_collectedStars;

        while (_timer <= m_starCountTime)
        {
            _timer += Time.deltaTime;
            m_starCounter = Mathf.FloorToInt(_timer / _betweenStars);

            m_text.text = $"{m_starCounter} / {m_maxStars}";

            yield return null;
        }

        m_text.text = $"{m_collectedStars} / {m_maxStars}";

    }

    //TODO
    public IEnumerator AllCollected()
    {
        Debug.Log("SMALL ANIMATION WITH SPARKLES AND MAYBE SOUND HERE");
        yield return null;
    }
}
