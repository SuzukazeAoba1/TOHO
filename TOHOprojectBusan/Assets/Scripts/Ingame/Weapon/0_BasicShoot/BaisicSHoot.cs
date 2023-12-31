using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaisicSHoot : MonoBehaviour
{
    public WeaponUpgrade grandparent;
    public WeaponData parentWeaponData;
    public GameObject Bullet;
    public float cooltime = 0.15f;
    public float bulletspeed = 200f;
    private float shoottimer = 0f;
    private AudioSource myAS;

    // Start is called before the first frame update

    private void Awake()
    {
        Transform parent = transform.parent;
        grandparent = parent.GetComponentInParent<WeaponUpgrade>();
        parentWeaponData = grandparent.weapon;
        myAS = GetComponent<AudioSource>();
        myAS.volume = 0.15f / parent.childCount;
    }
    void Start()
    {
        
    }

    private void OnEnable()
    {
        cooltime = parentWeaponData.cooltimes[grandparent.currentlevel-1];
    }

    // Update is called once per frame
    void Update()
    {
        shoottimer -= Time.deltaTime;
        if(shoottimer <= 0)
        {
            Shoot();
            shoottimer = cooltime;
        }
    }

    private void Shoot()
    {
        GameObject newBullet = GameManager.instance.BulletPool.Get(0);
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        newBullet.GetComponent<Bullet>().ATK = parentWeaponData.ATK[grandparent.currentlevel-1];
        newBullet.GetComponent<Bullet>().attackpoint = parentWeaponData.ATK[grandparent.currentlevel-1];
        myAS.Play();
            
        //GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed));
    }
}
