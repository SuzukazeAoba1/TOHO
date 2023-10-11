using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public EnemyBarrageController barrageController;
    Sequence mySequence;

    public float HP;
    public double speed;
    public bool test = false;

    private void Start()
    {
        InvokeRepeating("Fire", 2.0f, 2.0f);
    }

    private void Fire()
    {
        if (test) return;
        barrageController.Shoot(this.gameObject, false);
    }

    public void SetBarrageSetting(BarrageContainer con, BarrageSequence seq, BarragePatten pat)
    {
        barrageController = gameObject.AddComponent<EnemyBarrageController>();
        barrageController.Setting(con, seq, pat);
    }

    public void SetMoveSequence(Sequence seq)
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
