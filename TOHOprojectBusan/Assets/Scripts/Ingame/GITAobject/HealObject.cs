using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    public float speed = 7f;
    public float range = 1.5f;
    public float destroy_Time = 7f;
    public float addforce = 50f;

    private Transform target;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        Invoke("DeactivateSelf", destroy_Time);
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, addforce));
    }

    void Update()
    {
        if (target != null)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy < range)
            {
                shortestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }
    }
}