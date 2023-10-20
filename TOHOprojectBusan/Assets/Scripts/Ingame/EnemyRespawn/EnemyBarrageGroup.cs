using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrageGroup : MonoBehaviour
{
    private float spd;
    public int bulletcount;
    public float destroyDelay = 5.0f;

    void Start()
    { 
        //StartCoroutine(DestroyAfterDelay());
    }

    private void Update()
    {
        if(bulletcount <= 0) Destroy(gameObject);
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    public void SetSeq(float speed, float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        spd = speed;
    }
    void FixedUpdate()
    {
        transform.Translate(spd * Time.deltaTime * Vector2.up);
    }
}
