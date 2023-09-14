using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebugScript : MonoBehaviour
{
    public AudioClip m_test;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.instance.LevelStartPlayMusic(m_test);
    }
}
