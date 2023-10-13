using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Barrage"))
        {
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<Barrage>().Death();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Death();
        }
        else
        {
            Destroy(other.gameObject);
        }

    }
}
