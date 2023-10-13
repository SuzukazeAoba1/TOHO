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
        ShotSeq(enemy, player, flip);
    }

    private void ShotSeq(GameObject enemy, GameObject player, bool flip)
    {
        for (int i = 0; i < barrageseq.m_shotnum; i++)
        {
            ShotPatten(barrageseq.m_firstangle + barrageseq.m_perangle * i, enemy, player, flip);
        }
    }

    private void ShotPatten(int groupangle, GameObject enemy, GameObject player, bool flip)
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
            ShotBullet(bullet, pattengroup, enemy, player, flip);
        }

        group.bulletcount = bulletcount;

    }
    
    private void ShotBullet(BarrageData Barrage, GameObject pattengroup, GameObject enemy, GameObject player, bool flip)
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

        GameObject buf = Instantiate(barragecon.barrage[Barrage.m_barrageid], enemy.transform.position, barragerotation);
        buf.GetComponent<Barrage>().SetData(enemy, pattengroup, player, Barrage.m_basespeed, Barrage.m_addspeed, Barrage.m_distance, Barrage.m_delay / 60.0f);
        buf.GetComponent<SpriteRenderer>().sortingOrder = 999 - bulletcount;

        buf.SetActive(false);
        buf.GetComponent<Barrage>().ActiveTimerOn();


    }

    public void Setting(BarrageContainer con, BarrageSequence seq, BarragePatten pat)
    {
        barragecon = con;
        barrageseq = seq;
        barragepat = pat;
    }
}
