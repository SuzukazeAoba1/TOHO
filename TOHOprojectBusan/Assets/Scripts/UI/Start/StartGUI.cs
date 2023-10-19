using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGUI : MonoBehaviour
{
    public RectTransform tutorial;
    public RectTransform gameEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TutorialShow()
    {
        tutorial.localScale = new Vector3(2.8f, 2.8f, 2.8f);
    }
    public void TutorialHide()
    {
        tutorial.localScale = new Vector3(0, 0, 0);
    }

    public void EndShow()
    {
        gameEnd.localScale = new Vector3(2.8f, 2.8f, 2.8f);
    }
    public void EndHide()
    {
        gameEnd.localScale = new Vector3(0, 0, 0);
    }

    public void GoScene(string toGo)
    {
        SceneManager.LoadScene(toGo);
    }

    public void GameOff()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // 에디터에서는 에디터를 종료
        #else
            Application.Quit();  // 빌드된 게임에서는 게임을 종료
        #endif
    }
}
