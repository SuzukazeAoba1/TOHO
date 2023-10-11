using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrageController : MonoBehaviour
{
    public BarrageContainer barragecon;
    public BarrageSequence barrageseq;
    public BarragePatten barragepat;

    public void Shoot(GameObject enemy, bool flip)
    {
        ShotSeq(enemy, flip);
    }

    private void ShotSeq(GameObject enemy, bool flip)
    {
        ShotPatten(enemy, flip);
    }

    private void ShotPatten(GameObject enemy, bool flip)
    {
        foreach (var bullet in barragepat.patten)
        { 
            ShotBullet(bullet, enemy, flip);
            //bullet.m_targeting
        }
    }
    
    private void ShotBullet(BarrageData Barrage, GameObject enemy, bool flip)
    {
        float barrageangle;

        if (!flip)
        {
            barrageangle = - Barrage.m_angle;
        }
        else
        {
            barrageangle = - (360 - Barrage.m_angle);
        }

        GameObject buf = Instantiate(barragecon.barrage[Barrage.m_barrageid], enemy.transform.position, Quaternion.Euler(0, 0, barrageangle));
        buf.transform.Translate(Vector2.up * Barrage.m_distance * 0.1f);
        buf.GetComponent<Barrage>().myEnemy = enemy;
        buf.GetComponent<Barrage>().delay = Barrage.m_delay / 60.0f;
        buf.GetComponent<Barrage>().SetSpeed(Barrage.m_basespeed, Barrage.m_addspeed);
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
