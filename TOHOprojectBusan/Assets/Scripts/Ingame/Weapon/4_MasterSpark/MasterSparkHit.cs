using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSparkHit : MonoBehaviour
{
    public int ATK;
    private int attackpoint = 7;
    public int effectID = 4;
    private int eID = 3;

    public float Cooltime;

    public float destroy_Time;
    private GameObject damageText;
    private GameObject effect;
    private float bulletspeed;
    private float candamage = 0;
    public float offset = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        eID = effectID - 1;
        attackpoint = ATK;
        Player playerscript = FindObjectOfType<Player>();

        if (playerscript != null)
        {
            bulletspeed = playerscript.bulletspeed;
        }
        else
        {
            bulletspeed = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        candamage -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Color eC = other.GetComponent<SpriteRenderer>().color;
        if (candamage <= 0f)
        {
            candamage = Cooltime;
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Barrage"))
            {
                Destroy(other.gameObject);

            }
        }
    }
}