using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool _paused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    
    public bool IsPaused()
    {
        return _paused; 
    }

    public void TogglePause()
    {
        _paused = !_paused;
        pauseMenu.SetActive(_paused);

        Time.timeScale = _paused ? 0f : 1f;
    }
}
