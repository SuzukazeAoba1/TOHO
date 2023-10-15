using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaisicSHoot : MonoBehaviour
{
    public GameObject Bullet;
    public float cooltime = 0.15f;
    public float bulletspeed = 200f;
    private float shoottimer = 0f;
    private AudioSource myAS;

    // Start is called before the first frame update

    private void Awake()
    {
        myAS = GetComponent<AudioSource>();
        myAS.volume = 0.05f;
    }
    void Start()
    {
        
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
        myAS.Play();
            
        //GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed));
    }
}
