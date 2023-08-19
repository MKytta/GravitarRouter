using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public List<CollectableScript> m_collectables = new List<CollectableScript>();

    private UiManager m_uiManager;

    private int m_scoreValue = 0;
    private int m_displayValue = 0;

    void Start()
    {
        m_uiManager = GetComponent<UiManager>();

        GameObject _collectableParent = GameObject.FindGameObjectWithTag("CollectableParent");

        m_collectables.AddRange(_collectableParent.GetComponentsInChildren<CollectableScript>());

        for (int i = 0; i < m_collectables.Count; i++)
        {
            m_collectables[i].Initiate(this);
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

    public void ScoreCollected(Vector3 startPosition)
    {
        m_scoreValue += 1;

        m_uiManager.StarCollected(this, startPosition);
    }

    public void VisualScoreCollected()
    {
        m_displayValue += 1;

        m_uiManager.VisualStarCollected();
        m_uiManager.UpdateScore(m_displayValue, m_collectables.Count);
    }

    public void ScoreReset()
    {
        m_scoreValue = 0;
        m_displayValue = 0;

        m_uiManager.UpdateScore(m_displayValue, m_collectables.Count);
    }

    public int GetCollectedStars()
    {
        return m_scoreValue;
    }

    public int GetMaxStars()
    {
        return m_collectables.Count;
    }


}
