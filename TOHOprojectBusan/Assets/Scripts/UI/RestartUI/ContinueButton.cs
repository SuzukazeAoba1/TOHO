using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public GameManager gmanager;
    public Player player;
    public HealthGUI healthgui;
    public int select;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        switch (select)
        {
            case 1:
                gmanager.continued = true;
                gmanager.isDead = false;
                player.isdead = false;
                player.Invincibility(3f);
                break;
            case 2:
                SceneManager.LoadScene("Dead");
                break;
            default:
                break;
        }


    }
}
