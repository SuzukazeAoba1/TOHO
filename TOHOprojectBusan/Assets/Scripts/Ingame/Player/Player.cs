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
    public int health = 5;
    public float speed = 4.5f;
    public float bulletspeed = 200f;
    public float invincibility_time = 1.2f;
    private Vector3 position = Vector3.zero;
    private float H;
    private float V;
    private float xRange;
    private float yRange;

    private float damageTimer = 1f;
    private bool isdead = false;
    private bool isDamaged = false;
    private SpriteRenderer mySR;

    private GameObject damageText;
    private Vector3 offset = new Vector3(0, 1f, 0);
    

    // Start is called before the first frame update

    void Awake()
    {
        mySR = GetComponent<SpriteRenderer>();
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

        /*if (other.gameObject.CompareTag("Barrage"))
        {
            Damage();
        }*/


        if (other.gameObject.CompareTag("Experiance"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.GetExp(1);
        }
    }
    public void Damage()
    {
        if (!isDamaged)
        {
            if (health > 1)
            {
                isDamaged = true;
                health--;
                healthGui.HealhtPull();
                StartCoroutine(Hurt());
                StartCoroutine(Blink());
            }
            else if (health == 1)
            {
                healthGui.HealhtPull();
                Die();
            }
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

    IEnumerator Hurt()
    {
        while (isDamaged)
        {
            yield return new WaitForSeconds(invincibility_time);
        }
    }
    IEnumerator Blink()
    {
        while(isDamaged)
        {
            Color myC = mySR.color;
            yield return new WaitForSeconds(0.1f);
            mySR.color = new Color(myC.r / 3, myC.g / 3, myC.b / 3);
            yield return new WaitForSeconds(0.1f);
            mySR.color = myC;
        }
    }
}