using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;
    public float speed = 4.5f;
    public float cooltime = 0.15f;
    public float bulletspeed = 200f;
    private float shoottimer = 0f;
    public GameObject Bullet;
    public Transform ShootPoint;
    private Vector3 position = Vector3.zero;
    private float H;
    private float V;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        position.x = H;
        position.y = V;
        position.z = 0f;

        shoottimer -= Time.deltaTime;
        if(shoottimer <= 0f)
        {
            Shoot();
            shoottimer = cooltime;
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(position * speed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(Bullet, ShootPoint.position, Quaternion.Euler(0, 0, 90));
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed));
    }
}