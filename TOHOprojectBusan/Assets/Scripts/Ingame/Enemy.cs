using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    EnemyBarrageController barrageController;
    Sequence mySequence;

    public float HP;
    public double speed;

    private void Start()
    {
        barrageController = gameObject.AddComponent<EnemyBarrageController>();
        //시퀀스와 컨테이너 연결 필요
    }

    public void SetBarrageSetting(BarrageContainer con, BarrageSequence seq, BarragePatten pat)
    {
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
