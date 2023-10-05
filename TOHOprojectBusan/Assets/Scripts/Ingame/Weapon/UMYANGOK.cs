using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMYANGOK : MonoBehaviour
{
    public int per;
    public int ATK;
    public float Speed;
    public float destroy_Time;
    public GameObject DText;
    private float candamage = 0f;

    private void Update()
    {
        candamage -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().HP -= ATK;
            GameObject Damage = Instantiate(DText, transform.position, Quaternion.identity);
            Damage.GetComponent<TextMesh>().text = ATK.ToString();
            Destroy(Damage, 0.7f);
        }
        else if (other.gameObject.CompareTag("Barrage"))
        {
            if (ATK > other.gameObject.GetComponent<Barrage>().HP)
            {
                GameObject Damage = Instantiate(DText, transform.position, Quaternion.identity);
                Damage.GetComponent<TextMesh>().text = ATK.ToString();
                ATK -= other.gameObject.GetComponent<Barrage>().HP;
                //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2000f));
                Destroy(other.gameObject);
                Destroy(Damage, 0.7f);
            }
            else
            {
                other.gameObject.GetComponent<Barrage>().HP -= ATK;
                GameObject Damage = Instantiate(DText, transform.position, Quaternion.identity);
                Damage.GetComponent<TextMesh>().text = ATK.ToString();
                Destroy(Damage, 0.7f);
            }
        }
    }
}