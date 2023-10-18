using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReisenBullet : MonoBehaviour
{
    public WeaponUpgrade grandparent;
    public WeaponData parentWeaponData;
    public float radius = 1.0f;
    public int Shotcount = 2;
    public float cooltime = 0.15f;
    private float shoottimer = 0f;
    private AudioSource myAS;
    public float forceMagnitude = 1000.0f;

    private void Awake()
    {
        Transform parent = transform.parent;
        grandparent = parent.GetComponentInParent<WeaponUpgrade>();
        parentWeaponData = grandparent.weapon;
        myAS = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    private void OnEnable()
    {
        cooltime = parentWeaponData.cooltimes[grandparent.currentlevel-1];
        Shotcount = parentWeaponData.counts[grandparent.currentlevel-1];
    }
    private void Update()
    {
        shoottimer -= Time.deltaTime;
        if(shoottimer <= 0)
        {
            shoottimer = cooltime;
            Shoot();
        }
    }
    void Shoot()
    {
        for (int i = 0; i < Shotcount; i++)
        {
            float angle = i * (100f / Shotcount);
            Vector3 position = Quaternion.Euler(0, 0, (-36f) + angle) * new Vector3(0, radius, 0);;

            GameObject newbullet = GameManager.instance.BulletPool.Get(3);
            StartCoroutine(RestoreC(newbullet));
            newbullet.transform.position = transform.position;
            Color c = newbullet.GetComponent<SpriteRenderer>().color;
            newbullet.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 0f);
            newbullet.transform.rotation = Quaternion.AngleAxis((-35f) + angle, Vector3.forward);
            newbullet.GetComponent<Bullet>().ATK = parentWeaponData.ATK[grandparent.currentlevel - 1];
            newbullet.GetComponent<Bullet>().attackpoint = parentWeaponData.ATK[grandparent.currentlevel - 1];
            Rigidbody2D rb = newbullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // AddForce를 사용하여 힘을 가합니다.
                rb.AddForce(position.normalized * forceMagnitude);
            }
        }

        IEnumerator RestoreC(GameObject obj)
        {
            yield return new WaitForSeconds(0.07f);


            Color c = obj.GetComponent<SpriteRenderer>().color;
            obj.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 1f);
        }
    }
}