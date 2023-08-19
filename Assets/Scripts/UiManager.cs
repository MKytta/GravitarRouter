using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Canvas m_canvas;
    public GameObject m_levelCompletePanel;
    public TMPro.TMP_Text m_collectionText;
    public Image m_starImage;
    public RectTransform m_starPosition;

    public GameObject m_dummyCollectable;

    private LevelManager m_levelManager;
    private ScalePulse m_collectableStarPulse;

    void Start()
    {
        m_levelManager = gameObject.GetComponent<LevelManager>();
        m_canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        m_collectableStarPulse = m_starPosition.GetComponent<ScalePulse>();
    }


    void Update()
    {
        
    }

    public void LevelCompleted(int collectedStars, int maxStars)
    {
        GameObject _panel = Instantiate(m_levelCompletePanel, m_canvas.transform);
        _panel.GetComponent<LevelCompletePanel>().Initiate(m_levelManager, collectedStars, maxStars);
    }

    public void StarCollected(CollectablesManager collectablesManager, Vector3 startPosition)
    {
        GameObject _dummy = Instantiate(m_dummyCollectable, m_canvas.transform);

        Vector3 _screenPoint = Camera.main.WorldToScreenPoint(startPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_canvas.GetComponent<RectTransform>(), _screenPoint, null, out Vector2 _canvasPosition);

        Vector3 _modifiedEndPosition = m_starPosition.parent.localPosition + m_starPosition.localPosition;

        _dummy.GetComponent<DummyCollectable>().Initiate(collectablesManager, _canvasPosition, _modifiedEndPosition);
    }

    public void VisualStarCollected()
    {
        if (m_collectableStarPulse != null)
        {
            m_collectableStarPulse.ActivatePulse();
        }
        else
        {
            Debug.LogWarning("Collection effect not found.");
        }
    }

    public void UpdateScore(int current, int max)
    {
        m_collectionText.text = CreateScoreString(current, max);
    }

    private string CreateScoreString(int current, int max)
    {
        return $"{current} / {max}";
    }
}
