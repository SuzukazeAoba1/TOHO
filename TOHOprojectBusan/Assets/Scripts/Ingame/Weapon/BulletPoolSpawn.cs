using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolSpawn : MonoBehaviour
{
    public float shoottimer = 15f;
    private float canshoot = 0.05f;
    private float shootdealy = 0.05f;
    public int bulletId = 0;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoottimer -= Time.deltaTime;
        canshoot -= Time.deltaTime;
        if (shoottimer >= 0)
        {
            if(canshoot<=0)
            {
                Shoot();
            }
            
        }
    }

    private void Shoot()
    {
        GameObject newBullet = GameManager.instance.BulletPool.Get(bulletId);
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, 90);

        //GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600f));
    }
}
