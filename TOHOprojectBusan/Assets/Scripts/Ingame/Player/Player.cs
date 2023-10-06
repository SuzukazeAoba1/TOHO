using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;
    public float speed = 4.5f;
    public float bulletspeed = 200f;
    private Vector3 position = Vector3.zero;
    private float H;
    private float V;
    private float xRange = 9.8f;
    private float yRange = 13.8f;

    public float Helath = 5f;
    public float invincibility_time = 1.3f;
    private float damageTimer = 0f;
    private bool isdead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdead)
        {
            H = Input.GetAxis("Horizontal");
            V = Input.GetAxis("Vertical");
            position.x = H;
            position.y = V;
            position.z = 0f;

            if (Helath <= 0)
            {
                Dead();
            }
        }
    }
    private void FixedUpdate()
    {
        if(!isdead)
        {


            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, 0);
            }
            else if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, 0);
            }
            else if (transform.position.y < -yRange)
            {
                transform.position = new Vector3(transform.position.x, -yRange, 0);
            }
            else if (transform.position.y > yRange)
            {
                transform.position = new Vector3(transform.position.x, yRange, 0);
            }
            else
            {
                transform.Translate(position * speed * Time.fixedDeltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(damageTimer == 0)
            {
                Helath -= 1;
                damageTimer = invincibility_time;
                damageTimer -= Time.deltaTime;
            }

        }
        else if (collision.gameObject.CompareTag("Barrage"))
        {
            Destroy(collision.gameObject);
            if (damageTimer == 0)
            {
                Helath -= 1;
                damageTimer = invincibility_time;
                damageTimer -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Barrage"))
        {
            Destroy(other.gameObject);
            if (damageTimer == 0)
            {
                Helath -= 1;
                damageTimer = invincibility_time;
                damageTimer -= Time.deltaTime;
            }
        }
    }

    private void Dead()
    {
        isdead = true;
        position = Vector3.zero;
        Destroy(gameObject, 0);
    }


}