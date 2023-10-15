using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    public Transform target;
    public float range = 17f;
    private SpriteRenderer mySR;
    public string enemyTag = "Enemy";
    public float cooltime = 0.15f;
    private float shoottimer = 0f;
    private AudioSource myAS;
    
    public GameObject bullet;
    public float bulletspeed = 200f;
    public Transform ShootPoint;
    private float angle;
    private Quaternion rotation;
    private void Start()
    {
        myAS = GetComponent<AudioSource>();
        myAS.volume = 0.03f;
        mySR = GetComponent<SpriteRenderer>();
        InvokeRepeating("UpdateTraget", 0f, 0.02f);
    }

    void UpdateTraget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject neareatEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                neareatEnemy = enemy;
            }
        }

        if(neareatEnemy != null && shortesDistance <= range)
        {
            target = neareatEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        shoottimer -= Time.deltaTime;
        
        if (target)
        {
            if(target.position.x <= transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (target.position.x > transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (shoottimer <= 0)
            {
                ShooTraget();
                shoottimer = cooltime;
            }
            
        }
        else if (target == null)
        {
            if (shoottimer <= 0)
            {
                JustShoot();
                shoottimer = cooltime;
            }
        }

        
    }
    private void ShooTraget()
    {

        // target 위치와 현재 위치 사이의 방향 벡터를 구합니다.
        Vector2 direction = (target.position - transform.position).normalized;
        // 여기서 X축 방향으로 움직이기 위해 direction.x를 사용합니다.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject newDollBullet = GameManager.instance.BulletPool.Get(2);
        //GameObject newDollBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        newDollBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        newDollBullet.transform.position = ShootPoint.transform.position;
        newDollBullet.transform.Rotate(0, 0, 90);
        GetComponent<AudioSource>().Play();
        newDollBullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletspeed);
    }

    private void JustShoot()
    {
        GameObject JnewDollBullet = GameManager.instance.BulletPool.Get(2);
        JnewDollBullet.transform.position = ShootPoint.transform.position;
        //GameObject JnewDollBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
        JnewDollBullet.transform.rotation = Quaternion.Euler(0, 0, 180);
        GetComponent<AudioSource>().Play();
        JnewDollBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed));
    }
}