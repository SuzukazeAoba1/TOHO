using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameManager gmanager;
    AudioSource pausesound;
    public AudioSource background;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Awake()
    {
        pausesound = GetComponent<AudioSource>();


    }
    public void InPause(bool backgorundsound)
    {
        pausesound.Play();
        if (backgorundsound == false)
        {
            background.Pause();
        }
        if (gmanager.paused == false)
        {
            gmanager.paused = true;
        }
        
    }

    public void OutPause(bool backgorundsound)
    {

        if (gmanager.paused == true)
        {
            if (backgorundsound == false)
            {
                background.Play();
            }
            //pausesound.Play();
            gmanager.paused = false;
        }

    }


    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
