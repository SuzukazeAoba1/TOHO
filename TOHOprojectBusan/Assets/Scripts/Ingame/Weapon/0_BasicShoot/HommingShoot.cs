using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HommingShoot : MonoBehaviour
{
    public WeaponUpgrade grandparent;
    public WeaponData parentWeaponData;
    public Transform target;
    public float range = 17f;
    public string enemyTag = "Enemy";
    public string bossTag = "Boss";
    public float cooltime = 0.15f;
    private float shoottimer = 0f;

    public GameObject bullet;
    public float bulletspeed = 200f;
    private float angle;
    private Quaternion rotation;
    private AudioSource myAS;

    private void Awake()
    {
        Transform parent = transform.parent;
        grandparent = parent.GetComponentInParent<WeaponUpgrade>();
        parentWeaponData = grandparent.weapon;
        myAS = GetComponent<AudioSource>();
        myAS.volume = 0.25f / parent.childCount;
    }
    private void Start()
    {
        InvokeRepeating("UpdateTraget", 0f, 0.02f);
    }

    private void OnEnable()
    {
        cooltime = parentWeaponData.cooltimes[grandparent.currentlevel-1];
    }

    void UpdateTraget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag)
                                .Concat(GameObject.FindGameObjectsWithTag(bossTag))
                                .ToArray();
        float shortesDistance = Mathf.Infinity;
        GameObject neareatEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                neareatEnemy = enemy;
            }
        }

        if (neareatEnemy != null && shortesDistance <= range && transform.position.y <= neareatEnemy.transform.position.y)
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
        GameObject newDollBullet = GameManager.instance.BulletPool.Get(1);
        //GameObject newDollBullet = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        newDollBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        newDollBullet.transform.position = transform.position;
        newDollBullet.GetComponent<Bullet>().ATK = parentWeaponData.ATK[grandparent.currentlevel -1] - 2f;
        newDollBullet.GetComponent<Bullet>().attackpoint = parentWeaponData.ATK[grandparent.currentlevel -1] - 2f;
        newDollBullet.transform.Rotate(0, 0, 90);
        myAS.Play();
        newDollBullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletspeed);
    }

    private void JustShoot()
    {
        GameObject JnewDollBullet = GameManager.instance.BulletPool.Get(1);
        JnewDollBullet.transform.position = transform.position;
        //GameObject JnewDollBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
        JnewDollBullet.GetComponent<Bullet>().ATK = parentWeaponData.ATK[grandparent.currentlevel -1] - 1f;
        JnewDollBullet.GetComponent<Bullet>().attackpoint = parentWeaponData.ATK[grandparent.currentlevel -1] - 1f;
        JnewDollBullet.transform.Rotate(0, 0, 90);
        myAS.Play();
        JnewDollBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed));
    }


}