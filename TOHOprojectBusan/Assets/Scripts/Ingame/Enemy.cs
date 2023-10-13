using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public EnemyBarrageController barrageController;
    Sequence mySequence;

    public float HP;
    public double speed;
    public bool m_flip;
    public bool test = false;
    public float testcooltime = 3.0f;
    public bool isdamaged = false;
    private Color myColor;

    private void Start()
    {
        myColor = GetComponent<SpriteRenderer>().color;
        InvokeRepeating("Fire", testcooltime, testcooltime);
    }

    private void Update()
    {
        if(isdamaged)
        {
            Invoke("RestoreColor", 0.2f);
                    
        }
    }
    public void SetBarrageSetting(BarrageContainer con, BarrageSequence seq, BarragePatten pat, bool flip, float cooltime)
    {
        m_flip = flip;

        player = GameManager.instance.gameObject.GetComponent<GameManager>().player;
        barrageController = gameObject.AddComponent<EnemyBarrageController>();
        barrageController.Setting(con, seq, pat);
        testcooltime = cooltime / 10.0f;
    }

    public void SetMoveSequence(Sequence seq)
    {
        mySequence = seq;
    }

    private void Fire()
    {
        if (test) return;
        barrageController.Shoot(gameObject, player, m_flip);
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
        GameObject exp = GameManager.instance.GitaPool.Get(2);
        exp.transform.position = transform.position;
        mySequence.Kill(true);
        Destroy(gameObject);
    }

    private void RestoreColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = myColor;
        isdamaged = false;
    }
}
