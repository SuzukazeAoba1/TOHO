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
    public bool m_flip;
    public bool test = false;

    private void Start()
    {
        InvokeRepeating("Fire", 3.0f, 3.0f);
    }

    public void SetBarrageSetting(BarrageContainer con, BarrageSequence seq, BarragePatten pat, bool flip)
    {
        m_flip = flip;
        barrageController = gameObject.AddComponent<EnemyBarrageController>();
        barrageController.Setting(con, seq, pat); 
    }

    public void SetMoveSequence(Sequence seq)
    {
        mySequence = seq;
    }

    private void Fire()
    {
        if (test) return;
        barrageController.Shoot(this.gameObject, m_flip);
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
