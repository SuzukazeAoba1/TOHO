using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public int ATK;
    public float Speed;
    public float destroy_Time;
    public GameObject DText;
    private float bulletspeed;

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
        Destroy(gameObject, destroy_Time);
        TextMesh Damage_text = DText.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ATK <=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().HP -= ATK;
            GameObject Damage = Instantiate(DText, collision.contacts[0].point, Quaternion.identity);
            Damage.GetComponent<TextMesh>().text = ATK.ToString();
            Destroy(gameObject);
            Destroy(Damage, 0.7f);
            

        }
        else if (collision.gameObject.CompareTag("Barrage"))
        {
            if (ATK > collision.gameObject.GetComponent<Barrage>().HP)
            {

                
                GameObject Damage = Instantiate(DText, collision.contacts[0].point, Quaternion.identity);
                Damage.GetComponent<TextMesh>().text = ATK.ToString();
                ATK -= collision.gameObject.GetComponent<Barrage>().HP;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2000f));
                Destroy(collision.gameObject);
                Destroy(Damage, 0.7f);
            }
            else
            {
                collision.gameObject.GetComponent<Barrage>().HP -= ATK;
                GameObject Damage = Instantiate(DText, collision.contacts[0].point, Quaternion.identity);
                Damage.GetComponent<TextMesh>().text = ATK.ToString();
                Destroy(gameObject);
                Destroy(Damage, 0.7f);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrage"))
        {
            Vector3 hitPoint = other.transform.position;
            if (ATK > other.gameObject.GetComponent<Barrage>().HP)
            {

                ATK -= other.gameObject.GetComponent<Barrage>().HP;
                GameObject Damage = Instantiate(DText, hitPoint, Quaternion.identity);
                Damage.GetComponent<TextMesh>().text = ATK.ToString();
                Destroy(other.gameObject);
            }
            else
            {
                ATK -= other.gameObject.GetComponent<Barrage>().HP;
                GameObject Damage = Instantiate(DText, hitPoint, Quaternion.identity);
                Damage.GetComponent<TextMesh>().text = ATK.ToString();
                Destroy(gameObject);
                Destroy(Damage, 0.7f);
            }

        }
    }
}
