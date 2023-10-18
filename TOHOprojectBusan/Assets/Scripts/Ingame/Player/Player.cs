using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("# 외부 게임오브젝트")]
    public HealthGUI healthGui;
    public GameManager gManager;
    public InvincibilityUI invincibilityui;
    [Header ("# PlayerStatus")]
    public int maxHealth = 5;
    public int health = 5;
    public float speed = 4.5f;
    public float bulletspeed = 200f;
    public float invincibility_time = 1.2f;
    [Header("# 사운드효과")]
    private Vector3 position = Vector3.zero;
    private float H;
    private float V;
    private float xRange;
    private float yRange;

    private float damageTimer = 1f;
    public bool isdead = false;
    public bool isDamaged = false;
    private SpriteRenderer mySR;
    private Color originalcolor;

    [Header("# 치트 모드")]
    public ContinueUI cheatUI;
    public bool cheated = false;
    

    // Start is called before the first frame update

    void Awake()
    {
        mySR = GetComponent<SpriteRenderer>();
        originalcolor = mySR.color;
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
        if(Input.GetKey(KeyCode.P) && !cheated && !isDamaged)
        {
            cheated = true;
            cheatUI.Show();
        }
        
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
    private void OnTriggerEnter2D(Collider2D other)
    {
       


        if (other.gameObject.CompareTag("Experiance"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.GetExp(other.GetComponent<ExpObject>().EXP);
        }

        if (other.gameObject.CompareTag("Item"))
        {
            if (health < maxHealth)
            {
                Heal(1);
            }
            else if (health >= maxHealth && !cheated)
            {
                Invincibility(3f);
            }
            else
            {
                return;
            }
            other.gameObject.SetActive(false);
            GameManager.instance.GetExp(other.GetComponent<ExpObject>().EXP);
        }

    }

    public void Damage()
    {
        if (!isDamaged)
        {
            if (health > 1)
            {
                mySR.color = originalcolor;
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
        position = Vector3.zero;
        GameManager.instance.Die();
    }

    public void Heal(int count)
    {
        health += count;
        healthGui.HealthPush(count);

    }

    public void Invincibility(float time)
    {
        isDamaged = true;
        StartCoroutine(YellowBlink());
        StartCoroutine(Hitless(time));
        invincibilityui.time = time;
        

    }

    public void Cheat()
    {
        isDamaged = true;
        StartCoroutine(YellowBlink());
        invincibilityui.time = 9999;


    }

    IEnumerator Hurt()
    {
        while (isDamaged)
        {
            yield return new WaitForSeconds(invincibility_time);
            isDamaged = false;
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

    IEnumerator YellowBlink()
    {
        while (isDamaged)
        {
            Color myC = mySR.color;
            yield return new WaitForSeconds(0.1f);
            mySR.color = new Color(myC.r, myC.g, 0);
            yield return new WaitForSeconds(0.1f);
            mySR.color = myC;
        }
    }

    IEnumerator Hitless(float time)
    {
        yield return new WaitForSeconds(time);
       isDamaged = false;
    }
}