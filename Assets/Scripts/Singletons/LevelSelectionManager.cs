using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    public static LevelSelectionManager instance;

    private LevelSelectionManager m_levelSelectionManager;

    private int m_currentLevel = 1;
    private readonly string m_levelPrefix = "DemoLevel_";

    private void Awake()
    {
        m_levelSelectionManager = GetComponent<LevelSelectionManager>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadLevel(int level)
    {
        SetCurrentLevel(level);
        LoadNamedScene($"{m_levelPrefix}{level}");
    }

    public void LoadNamedScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadMenuScene()
    {
        LoadNamedScene("MainMenu");
    }

    public void SetCurrentLevel(int currentLevel)
    {
        m_currentLevel = currentLevel;
    }

    public void AdvanceLevel()
    {
        int _nextLevel = m_currentLevel + 1;
        if (_nextLevel <= SceneManager.sceneCountInBuildSettings - 2)
        {
            LoadLevel(_nextLevel);
        }
        else
        {
            LoadNamedScene("DemoEnd");
        }
    }

    public int GetCurrentLevel()
    {
        return m_currentLevel;
    }

}
