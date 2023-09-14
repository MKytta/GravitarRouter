using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
        StateManager.instance.SetState(StateManager.States.Pause);
    }

    void Update()
    {
        
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
