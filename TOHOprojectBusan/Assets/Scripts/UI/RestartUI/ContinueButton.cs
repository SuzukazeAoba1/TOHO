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
                player.isDamaged = true;
                player.health = player.maxHealth;
                healthgui.HealthSet(player.maxHealth);
                StartCoroutine(Blink());
                StartCoroutine(Resurectioned());
                break;
            case 2:
                SceneManager.LoadScene("Dead");
                break;
            default:
                break;
        }


    }

    IEnumerator Blink()
    {
        while (player.isDamaged)
        {
            Color myC = player.gameObject.GetComponent<SpriteRenderer>().color;
            yield return new WaitForSeconds(0.1f);
            player.gameObject.GetComponent<SpriteRenderer>().color = new Color(myC.r, myC.g, 0);
            yield return new WaitForSeconds(0.1f);
            player.gameObject.GetComponent<SpriteRenderer>().color = myC;
        }
    }

    IEnumerator Resurectioned()
    {
        yield return new WaitForSeconds(2f);
        player.isDamaged = false;
    }
}
