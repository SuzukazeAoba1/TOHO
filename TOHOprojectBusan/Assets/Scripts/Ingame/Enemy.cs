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
    private bool isDamaged = false;
    private SpriteRenderer mySR;

    private void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        InvokeRepeating("Fire", 3.0f, 3.0f);
    }

    public void SetBarrageSetting(BarrageContainer con, BarrageSequence seq, BarragePatten pat, bool flip)
    {
        m_flip = flip;

        player = GameManager.instance.gameObject.GetComponent<GameManager>().player;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            isDamaged = true;
            StartCoroutine(Hurt());
            StartCoroutine(Blink());
        }
    }
    public void Death()
    {
        GameObject exp = GameManager.instance.GitaPool.Get(1);
        exp.transform.position = transform.position;
        mySequence.Kill(true);
        Destroy(gameObject);
    }

    IEnumerator Hurt()
    {
        while (isDamaged)
        {
            yield return new WaitForSeconds(0.1f);
            isDamaged = false;
        }
    }
    IEnumerator Blink()
    {
        while (isDamaged)
        {
            Color myC = mySR.color;
            yield return new WaitForSeconds(0.05f);
            mySR.color = new Color(myC.r / 3, myC.g / 3, myC.b / 3);
            yield return new WaitForSeconds(0.05f);
            mySR.color = myC;
        }
    }
}
