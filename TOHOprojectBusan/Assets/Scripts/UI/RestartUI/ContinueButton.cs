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
                gmanager.cflag = true;
                gmanager.isDead = false;
                player.isdead = false;
                player.health = player.maxHealth;
                healthgui.HealthSet(5);
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
