using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrageController : MonoBehaviour
{
    public BarrageContainer barragecon;
    public BarrageSequence barrageseq;
    public BarragePatten barragepat;

    public void Shoot(GameObject enemy, GameObject player, bool flip)
    {
        ShotSeq(enemy, player, flip);
    }

    private void ShotSeq(GameObject enemy, GameObject player, bool flip)
    { 
        ShotPatten(enemy, player, flip);
    }

    private void ShotPatten(GameObject enemy, GameObject player, bool flip)
    {

        foreach (var bullet in barragepat.patten) //패턴 그룹
        { 
            ShotBullet(bullet, enemy, player, flip);
        }

    }
    
    private void ShotBullet(BarrageData Barrage, GameObject enemy, GameObject player, bool flip)
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
        buf.GetComponent<Barrage>().SetData(enemy, player, Barrage.m_basespeed, Barrage.m_addspeed, Barrage.m_distance, Barrage.m_delay / 60.0f);

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
