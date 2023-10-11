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
            GameObject barrage = Instantiate(barragecon.barrage[bullet.m_barrageid], enemy.transform.position, Quaternion.Euler(0, 0, -bullet.m_angle));
            barrage.transform.Translate(Vector2.up * bullet.m_distance);
            barrage.GetComponent<Barrage>().Speed = bullet.m_basespeed;
            barrage.GetComponent<Barrage>().add_Speed = bullet.m_addspeed;
        }
    }


    public void Setting(BarrageContainer con, BarrageSequence seq, BarragePatten pat)
    {
        barragecon = con;
        barrageseq = seq;
        barragepat = pat;
    }
}
