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

    public bool bosspatten1 = false;
    public bool bosspatten2 = false;

    private void Start()
    {
        myColor = GetComponent<SpriteRenderer>().color;

        Invoke("Fire", firstcooltime);

        if (bosspatten1)
        {
            StartCoroutine("BossPattenChange1");
        }
        else if (bosspatten2)
        {
            StartCoroutine("BossPattenChange2");
        }
    }

    private void Update()
    {
        if (isdamaged)
        {
            Invoke("RestoreColor", 0.2f);
        }
    }
    private void Fire()
    {
        if (test) return;
        barrageController.Shoot(gameObject, player, m_flip);
    }


    IEnumerator BossPattenChange1()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            SetBarrageChange(GameManager.instance.GetComponent<EnemySpawnController>().BarrageSequence.List[228],
                             GameManager.instance.GetComponent<EnemySpawnController>().BarragePatten.List[87]);
            yield return new WaitForSeconds(11.0f);
            SetBarrageChange(GameManager.instance.GetComponent<EnemySpawnController>().BarrageSequence.List[229],
                             GameManager.instance.GetComponent<EnemySpawnController>().BarragePatten.List[88]);
        }
    }

    IEnumerator BossPattenChange2()
    {
        while (true)
        {
            yield return new WaitForSeconds(8.0f);
            SetBarrageChange(GameManager.instance.GetComponent<EnemySpawnController>().BarrageSequence.List[223],
                             GameManager.instance.GetComponent<EnemySpawnController>().BarragePatten.List[82]);
            yield return new WaitForSeconds(10.0f);
            SetBarrageChange(GameManager.instance.GetComponent<EnemySpawnController>().BarrageSequence.List[224],
                             GameManager.instance.GetComponent<EnemySpawnController>().BarragePatten.List[83]);
            yield return new WaitForSeconds(5.0f);
            SetBarrageChange(GameManager.instance.GetComponent<EnemySpawnController>().BarrageSequence.List[225],
                             GameManager.instance.GetComponent<EnemySpawnController>().BarragePatten.List[84]);
            yield return new WaitForSeconds(4.0f);
            SetBarrageChange(GameManager.instance.GetComponent<EnemySpawnController>().BarrageSequence.List[226],
                             GameManager.instance.GetComponent<EnemySpawnController>().BarragePatten.List[85]);
            yield return new WaitForSeconds(11.0f);
            SetBarrageChange(GameManager.instance.GetComponent<EnemySpawnController>().BarrageSequence.List[227],
                             GameManager.instance.GetComponent<EnemySpawnController>().BarragePatten.List[86]);
        }
    }


        public void SetBarrageChange(BarrageSequence seq, BarragePatten pat)
    {
        barrageController.Change(seq, pat);
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
