using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrage : MonoBehaviour
{
    public float HP;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    public float Pierce(float atk)
    {
        if(HP <= atk)
        {
            return 0;
        }
        else if(atk > HP)
        {
            return HP - atk;
        }
        else
        {
            return 0;
        }
            
    }
    public void Damage(float atk)
    {
        HP -= atk;

        if (HP <= 0)
        {
            Death();
        }
    }
    void Update()
    {

        if (HP <= 0)
        {
            GameObject exp = GameManager.instance.GitaPool.Get(1);
            exp.transform.position = transform.position;
            transform.DOKill();
            Destroy(gameObject);
        }
    }
    //private void ondestroy()
    //{
    //    gameobject exp = gamemanager.instance.gitapool.get(1);
    //    exp.transform.position = transform.position;
    //}

    public void Death()
    {
        GameObject exp = GameManager.instance.GitaPool.Get(1);
        exp.transform.position = transform.position;
        Destroy(gameObject);
    }

}
