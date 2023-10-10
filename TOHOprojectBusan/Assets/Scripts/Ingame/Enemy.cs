using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    Sequence mySequence;
    public float HP;
    public double speed;

    public void SetSequence(Sequence seq)
    {
        mySequence = seq;
    }


    public float Damage(float atk)
    {
        HP -= atk;

        if (HP <= 0)
        {
            Death();
        }

        if (HP > atk) return 0;
        else return atk - HP;
    }

    public void Death()
    {
        GameObject exp = GameManager.instance.GitaPool.Get(1);
        exp.transform.position = transform.position;
        mySequence.Kill(true);
        Destroy(gameObject);
    }
}
