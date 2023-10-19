using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject m_options;

    private bool m_isOptionsOpen = false;

    void Start()
    {
        Time.timeScale = 0f;
        StateManager.instance.SetState(StateManager.States.Pause);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (m_isOptionsOpen == true)
            {
                CloseOptions();
            }
            else
            {
                ResumeGame();
            }

        }

    }

    public void OpenOptions()
    {
        m_isOptionsOpen = true;
        m_options.SetActive(true);
    }

    public void CloseOptions()
    {
        m_isOptionsOpen = false;
        m_options.SetActive(false);
    }

    public void GoToMenu()
    {
        ResumeTimeScale();
        LevelSelectionManager.instance.LoadMenuScene();
    }

    public void ResumeGame()
    {
        ResumeTimeScale();
        StateManager.instance.ResumePreviousState();
        Destroy(gameObject);
    }

    public void ResumeTimeScale()
    {
        Time.timeScale = 1f;
    }
}
