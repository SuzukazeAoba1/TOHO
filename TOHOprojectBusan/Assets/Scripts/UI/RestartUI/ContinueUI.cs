using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueUI : MonoBehaviour
{
    RectTransform rect;
    ContinueButton[] Buttons;
    AudioSource pausesound;
    public AudioSource background;
    private bool isPaused;
    public int selectcount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        pausesound = GetComponent<AudioSource>();
        rect = GetComponent<RectTransform>();
        Buttons = GetComponentsInChildren<ContinueButton>(true);


    }

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        //background.Pause();
        //pausesound.Play();
        //pausesound.Play();
        GameManager.instance.PuaseManger.InPause(false);
        rect.localScale = new Vector3(1, 1, 1);
        
        //TogglePause();
    }

    public void Hide()
    {
        //background.Play();
        Debug.Log("¼û°ÜÁü");
        GameManager.instance.PuaseManger.OutPause(false);
        rect.localScale = new Vector3(0, 0, 0);
        
        //TogglePause();
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
