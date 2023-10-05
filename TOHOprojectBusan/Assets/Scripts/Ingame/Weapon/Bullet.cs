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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().HP -= ATK;
            GameObject Damage = Instantiate(DText, transform.position, Quaternion.identity);
            Damage.GetComponent<TextMesh>().text = ATK.ToString();
            Destroy(gameObject);
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
                Destroy(gameObject);
                Destroy(Damage, 0.7f);
            }
        }
    }
}
