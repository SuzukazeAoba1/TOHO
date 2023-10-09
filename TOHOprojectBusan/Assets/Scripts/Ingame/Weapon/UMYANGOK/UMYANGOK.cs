using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMYANGOK : MonoBehaviour
{
    public int ATK;
    private int attackpoint = 7;

    public float Cooltime;

    public float destroy_Time;
    private GameObject damageText;
    private float bulletspeed;
    private float candamage = 0;
    private Vector3 offset = new Vector3(0, 1f, 0);

    // Start is called before the first frame update
    void Start()
    {
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
                other.gameObject.GetComponent<Enemy>().HP -= attackpoint;
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = transform.position + offset;
                damageText.transform.localScale = new Vector3(other.transform.localScale.x / 5, other.transform.localScale.x / 5, other.transform.localScale.x / 5);
                damageText.GetComponent<TextMesh>().text = attackpoint.ToString();
            }
            else if (other.gameObject.CompareTag("Barrage"))
            {

                other.gameObject.GetComponent<Barrage>().HP -= attackpoint;
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = transform.position + offset;
                damageText.transform.localScale = new Vector3(other.transform.localScale.x / 5, other.transform.localScale.x / 5, other.transform.localScale.x / 5);
                damageText.GetComponent<TextMesh>().text = attackpoint.ToString();

            }
        }
    }
}
