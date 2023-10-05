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

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroy_Time);
        TextMesh Damage_text = DText.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
