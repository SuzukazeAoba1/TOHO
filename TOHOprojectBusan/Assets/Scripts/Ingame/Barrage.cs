using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrage : MonoBehaviour
{
    public int HP;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (HP <= 0)
        {
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}
