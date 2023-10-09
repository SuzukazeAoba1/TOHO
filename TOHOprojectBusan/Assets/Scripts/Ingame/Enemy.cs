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

    public void Damage(int atk)
    {
        HP -= atk;

        if (HP <= 0)
        {
            Debug.Log("death");
            Death();
        }
    }

    public void Death()
    {
        mySequence.Kill(true);
        Destroy(gameObject);
    }
}
