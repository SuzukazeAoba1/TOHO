using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public float HP;
    public double speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP -= 0.01f;
        if (HP <= 0)
        {
            transform.DOKill();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
