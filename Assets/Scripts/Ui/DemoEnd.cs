using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEnd : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BackToMenu()
    {
        LevelSelectionManager.instance.LoadNamedScene("MainMenu");
    }
}
