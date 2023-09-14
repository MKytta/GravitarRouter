using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SelectLevel(int level)
    {
        LevelSelectionManager.instance.LoadLevel(level);
    }
}
