using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMYANGOK : MonoBehaviour
{
    public int ATK;
    public float Cooltime;
    public float destroy_Time;
    public GameObject DText;
    private float bulletspeed;
    private float candamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player playerscript = FindObjectOfType<Player>();

        if (playerscript != null)
        {
            bulletspeed = playerscript.bulletspeed;
        }
        else
        {
            bulletspeed = 0f;
        }
        TextMesh Damage_text = DText.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        candamage -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (candamage <= 0f)
        {
            candamage = Cooltime;
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().HP -= ATK;
            }
            else if (other.gameObject.CompareTag("Barrage"))
            {

                other.gameObject.GetComponent<Barrage>().HP -= ATK;

            }
        }
    }
}
