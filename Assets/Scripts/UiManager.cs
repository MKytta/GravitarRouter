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

    private LevelManager m_levelManager;

    void Start()
    {
        m_levelManager = gameObject.GetComponent<LevelManager>();
        m_canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }


    void Update()
    {
        
    }

    public void LevelCompleted(int collectedStars, int maxStars)
    {
        GameObject _panel = Instantiate(m_levelCompletePanel, m_canvas.transform);
        _panel.GetComponent<LevelCompletePanel>().Initiate(m_levelManager, collectedStars, maxStars);
    }

    public void StarCollected(Vector3 starPosition)
    {

    }
}
