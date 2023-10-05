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
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().HP -= ATK;
            GameObject Damage = Instantiate(DText, transform.position, Quaternion.identity);
            Damage.GetComponent<TextMesh>().text = ATK.ToString();
            Destroy(Damage, 0.7f);
        }
        else if (other.CompareTag("Barrage"))
        {
                other.GetComponent<Barrage>().HP -= ATK;
                GameObject Damage = Instantiate(DText, transform.position, Quaternion.identity);
                Damage.GetComponent<TextMesh>().text = ATK.ToString();
                Destroy(Damage, 0.7f);
        }
    }
}