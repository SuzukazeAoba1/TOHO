using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameManager gmanager;
    RectTransform rect;
    ContinueButton[] Buttons;
    AudioSource pausesound;
    public AudioSource background;
    private bool isPaused;
    private bool opened =  false;
    public int selectcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!opened && GameManager.instance.paused == false)
            {
                Show();
                opened = true;


            }
            else if(opened && GameManager.instance.paused == true)
            {
                Hide();
                opened = false;


            }
            
        }
    }
    void Awake()
    {
        pausesound = GetComponent<AudioSource>();
        rect = GetComponent<RectTransform>();
        Buttons = GetComponentsInChildren<ContinueButton>(true);


    }
    public void Show()
    {
        if (GameManager.instance.paused == false)
        {
            GameManager.instance.PuaseManger.InPause(false);
            rect.localScale = new Vector3(1, 1, 1);
        }
        //background.Pause();
        //pausesound.Play();
        
        //TogglePause();
    }

    public void Hide()
    {
        //background.Play();
        //Debug.Log("¼û°ÜÁü");
        GameManager.instance.PuaseManger.OutPause(false);
        rect.localScale = new Vector3(0, 0, 0);
        //TogglePause();
    }


    /*void TogglePause()
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
    }*/

    public void Onclick(int id)
    {
        switch(id)
        {
            case 0:
                Hide();
                opened = false;
                break;
            case 1:
                SceneManager.LoadScene("Start");
                break;

        }
    }
}
