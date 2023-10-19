using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

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
            if(!opened)
            {
                Show();
                opened = true;
            }
            else if(opened)
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
        background.Pause();
        pausesound.Play();
        rect.localScale = new Vector3(1, 1, 1);
        TogglePause();
    }

    public void Hide()
    {
        background.Play();
        Debug.Log("¼û°ÜÁü");
        rect.localScale = new Vector3(0, 0, 0);
        TogglePause();
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

    public void Onclick(int id)
    {
        switch(id)
        {
            case 0:
                Hide();
                break;
            case 1:
                SceneManager.LoadScene("Start");
                break;

        }
    }
}
