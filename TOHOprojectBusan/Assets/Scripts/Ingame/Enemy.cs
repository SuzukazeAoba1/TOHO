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
    public float firstcooltime = 1f;

    public bool isdamaged = false;
    private Color myColor;

    private void Start()
    {
        myColor = GetComponent<SpriteRenderer>().color;
        Invoke("Fire", firstcooltime);
    }

    private void Update()
    {
        if(isdamaged)
        {
            Invoke("RestoreColor", 0.2f);        
        }
    }
    private void Fire()
    {
        if (test) return;
        barrageController.Shoot(gameObject, player, m_flip);
    }

    public void SetBarrageSetting(BarrageContainer con, BarrageSequence seq, BarragePatten pat, bool flip, float cooltime)
    {
        m_flip = flip;

        player = GameManager.instance.gameObject.GetComponent<GameManager>().player;
        barrageController = gameObject.AddComponent<EnemyBarrageController>();
        barrageController.Setting(con, seq, pat);
        firstcooltime = seq.m_shotfirst;

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
            Kill();
        }

        if (HP > atk) return 0;
        else return atk - HP;
    }

    
    public void Kill()
    {
        GameObject exp = GameManager.instance.GitaPool.Get(2);
        exp.transform.position = transform.position;

        mySequence.Kill(true);
        Destroy(gameObject);
    }

    public void Death()
    {
        mySequence.Kill(true);
        Destroy(gameObject);
    }

    private void RestoreColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = myColor;
        isdamaged = false;
    }
}
