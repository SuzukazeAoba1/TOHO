using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrageController : MonoBehaviour
{
    public BarrageContainer barragecon;
    public BarrageSequence barrageseq;
    public BarragePatten barragepat;

    public int bulletcount;


    public void Shoot(GameObject enemy, GameObject player, bool flip)
    {
        StartCoroutine(ShotSeq(enemy, player, flip)); //test
    }

    private IEnumerator ShotSeq(GameObject enemy, GameObject player, bool flip)
    {
        while (true)
        {
            for (int i = 0; i < barrageseq.m_shotnum; i++)
            {
                float angle;

                if(barrageseq.m_target)
                {
                    Vector2 dir = player.transform.position - enemy.transform.position;
                    angle =  180 - ((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90);
                }
                else
                {
                    angle = barrageseq.m_firstangle + barrageseq.m_perangle * i;
                }
                ShotPatten(angle, enemy, player, flip, i);
                yield return new WaitForSeconds(barrageseq.m_shotinterval);
            }
            yield return new WaitForSeconds(barrageseq.m_shotlooptime);
        }
    }

    private void ShotPatten(float groupangle, GameObject enemy, GameObject player, bool flip, int pattennum)
    {
        GameObject pattengroup = new GameObject();
        pattengroup.transform.position = enemy.transform.position;
        pattengroup.name = "barragepatten " + barrageseq.m_barragepattenid;

        EnemyBarrageGroup group = pattengroup.AddComponent<EnemyBarrageGroup>();
        group.SetSeq(barrageseq.m_basevector, groupangle);

        bulletcount = 0;

        foreach (var bullet in barragepat.patten) //패턴 그룹
        {
            bulletcount++;
            ShotBullet(bullet, pattengroup, enemy, player, flip, pattennum);
        }

        group.bulletcount = bulletcount;

    }
    
    private void ShotBullet(BarrageData Barrage, GameObject pattengroup, GameObject enemy, GameObject player,bool flip, int pattennum)
    {
        float barrageangle;
        Quaternion barragerotation;

        if (!flip)
        {
            barrageangle = -Barrage.m_angle;
            barragerotation = Quaternion.Euler(0, 0, barrageangle);
        }
        else
        {
            barrageangle = -(360 - Barrage.m_angle);
            barragerotation = Quaternion.Euler(0, 0, barrageangle);
        }

        //GameObject buf = Instantiate(barragecon.barrage[Barrage.m_barrageid], enemy.transform.position, barragerotation);
        GameObject buf = GameManager.instance.BarragePool.Get(Barrage.m_barrageid);
        buf.transform.position = enemy.transform.position;
        buf.transform.rotation = barragerotation;

        buf.GetComponent<Barrage>().SetData(enemy, pattengroup, player, Barrage.m_basespeed, Barrage.m_addspeed, Barrage.m_distance, Barrage.m_delay / 60.0f);
        buf.GetComponent<SpriteRenderer>().sortingOrder = 999 - (pattennum * 10) - bulletcount; 

        buf.SetActive(false);
        buf.GetComponent<Barrage>().ActiveTimerOn();

    }

    public void Setting(BarrageContainer con, BarrageSequence seq, BarragePatten pat)
    {
        barragecon = con;
        barrageseq = seq;
        barragepat = pat;
    }

    public void Change(BarrageSequence seq, BarragePatten pat)
    {
        barrageseq = seq;
        barragepat = pat;
    }
}
