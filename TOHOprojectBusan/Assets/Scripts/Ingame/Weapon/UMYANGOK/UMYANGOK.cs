using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMYANGOK : MonoBehaviour
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
    private Vector3 offset = new Vector2(0, 1f);

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
        if (candamage <= 0f)
        {
            candamage = Cooltime;
            if (other.gameObject.CompareTag("Enemy"))
            {
                effect = GameManager.instance.EffectPool.Get(eID);
                effect.transform.position = other.ClosestPoint(transform.position);
                other.gameObject.GetComponent<Enemy>().HP -= attackpoint;
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = other.ClosestPoint(transform.position);
                damageText.GetComponent<TextMesh>().text = attackpoint.ToString();
            }
            else if (other.gameObject.CompareTag("Barrage"))
            {

                effect = GameManager.instance.EffectPool.Get(eID);
                effect.transform.position = other.ClosestPoint(transform.position);
                other.gameObject.GetComponent<Barrage>().HP -= attackpoint;
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = other.ClosestPoint(transform.position);
                //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 5, other.transform.localScale.x / 5, other.transform.localScale.x / 5);
                damageText.GetComponent<TextMesh>().text = attackpoint.ToString();

            }
        }
    }
}
