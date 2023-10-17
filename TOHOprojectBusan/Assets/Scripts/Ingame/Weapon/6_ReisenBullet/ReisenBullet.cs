using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReisenBullet : MonoBehaviour
{
    public float radius = 1.0f;
    public int pointCount = 2;
    public float time_to_shot;
    private float cooltime = 1.0f;

    public float forceMagnitude = 1000.0f;

    private void Awake()
    {
        cooltime = time_to_shot;
    }
    void Start()
    {
        
    }

    private void Update()
    {
        cooltime -= Time.deltaTime;
        if(cooltime <= 0)
        {
            cooltime = time_to_shot;
            Shoot();
        }
    }
    void Shoot()
    {
        for (int i = 0; i < pointCount; i++)
        {
            float angle = i * (100f / pointCount);
            Vector3 position = Quaternion.Euler(0, 0, (-36f) + angle) * new Vector3(0, radius, 0);;

            GameObject newObj = GameManager.instance.BulletPool.Get(3);
            StartCoroutine(RestoreC(newObj));
            newObj.transform.position = transform.position;
            Color c = newObj.GetComponent<SpriteRenderer>().color;
            newObj.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 0f);
            newObj.transform.rotation = Quaternion.AngleAxis((-35f) + angle, Vector3.forward);
            Rigidbody2D rb = newObj.GetComponent<Rigidbody2D>();

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