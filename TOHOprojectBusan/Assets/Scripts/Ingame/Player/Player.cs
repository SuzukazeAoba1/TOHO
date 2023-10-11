using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("# 외부 게임오브젝트")]
    public HealthGUI healthGui;
    public GameManager gManager;
    [Header ("# PlayerStatus")]
    public int maxHealth = 5;
    private int health = 5;
    public float speed = 4.5f;
    public float bulletspeed = 200f;
    private Vector3 position = Vector3.zero;
    private float H;
    private float V;
    private float xRange;
    private float yRange;

    public float invincibility_time = 1.3f;
    private float damageTimer = 1f;
    private bool isdead = false;

    private GameObject damageText;
    private Vector3 offset = new Vector3(0, 1f, 0);
    

    // Start is called before the first frame update

    void Awake()
    {
        xRange = (gManager.gameObject.GetComponent<GameManager>().movingzone.x - 1) /2;
        yRange = (gManager.gameObject.GetComponent<GameManager>().movingzone.y - 1) / 2;
        health = maxHealth;
        healthGui.HealthSet(health);
    }
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

        }
    }
    private void FixedUpdate()
    {
        damageTimer -= Time.fixedDeltaTime;

        if (!isdead)
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


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrage"))
        {
            Destroy(other.gameObject);
            if (damageTimer == 0)
            {
                Damage();
                damageTimer = invincibility_time;
                damageTimer -= Time.deltaTime;
            }
        }

        if (other.CompareTag("Experiance"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.GetExp(other.GetComponent<ExpObject>().EXP);
        }
    }

    private void Dead()
    {
        isdead = true;
        position = Vector3.zero;
        Destroy(gameObject, 0);
    }

    void Damage()
    {
        
        if(health > 1)
        {
            health--;
        }
        else if(health == 1)
        {

        }
            
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.gameObject.CompareTag("Enemy"))
        {

            if (damageTimer == 0)
            {
                Damage();
                healthGui.HealthPush(health);
                damageTimer = invincibility_time;
            }

        }*/
        
        if (other.gameObject.CompareTag("Barrage"))
        {
                Damage();
                Destroy(other.gameObject);
                Debug.Log("대미지 입음");
            
                damageTimer = invincibility_time;

        }

        if (other.gameObject.CompareTag("Experiance"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.GetExp(1);
        }
    }
    void Damage()
    {

        if (health > 1)
        {
            health--;
            healthGui.HealhtPull();
        }
        else if (health == 1)
        {
            Die();
        }
    }
    void Die()
    {
        isdead = true;
    }

    public void Heal(int count)
    {
        health += count;
        healthGui.HealthPush(count);

    }

}