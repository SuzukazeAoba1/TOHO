using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObject : MonoBehaviour
{
    public Transform target;
    public float range = 1.5f;
    public float speed = 7f;
    public int EXP = 1;
    public float destroy_Time = 7f;
    public float addforce = 50f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("DeactivateSelf", destroy_Time);
        InvokeRepeating("UpdateTraget", 0f, 0.2f);
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, addforce));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * speed);
        }
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }

    void UpdateTraget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
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

        if (neareatEnemy != null && shortesDistance <= range)
        {
            target = neareatEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
