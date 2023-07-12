using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CollectablesManager : MonoBehaviour
{
    public List<CollectableScript> m_collectables = new List<CollectableScript>();
    public TMPro.TMP_Text m_collectedText;

    public static event UnityAction OnCollection;

    private int m_collectedValue = 0;

    void Start()
    {
        GameObject _collectableParent = GameObject.FindGameObjectWithTag("CollectableParent");

        m_collectables.AddRange(_collectableParent.GetComponentsInChildren<CollectableScript>());

        OnCollection = ScoreUpdate;

        for (int i = 0; i < m_collectables.Count; i++)
        {
            m_collectables[i].Initiate(OnCollection);
        }

        ScoreReset();
    }

    void Update()
    {
        
    }

    public void ResetCollectables()
    {
        ScoreReset();
        for (int i = 0; i < m_collectables.Count; i++)
        {
            m_collectables[i].ResetCollectible();
        }
    }

    public void ScoreUpdate()
    {
        m_collectedValue += 1;

        m_collectedText.text = CreateScoreString(m_collectedValue, m_collectables.Count);
    }

    public void ScoreReset()
    {
        m_collectedValue = 0;

        m_collectedText.text = CreateScoreString(m_collectedValue, m_collectables.Count);
    }

    public int GetCollectedStars()
    {
        return m_collectedValue;
    }

    public int GetMaxStars()
    {
        return m_collectables.Count;
    }

    private string CreateScoreString(int current, int max)
    {
        return $"{current} / {max}";
    }
}
