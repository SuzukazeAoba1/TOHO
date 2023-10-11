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
        GameObject barrage = Instantiate(barragecon.barrage[0], enemy.transform.position, Quaternion.Euler(0,0,-180));
        barrage.GetComponent<Barrage>().Speed = 10;
    }


    public void Setting(BarrageContainer con, BarrageSequence seq, BarragePatten pat)
    {
        barragecon = con;
        barrageseq = seq;
        barragepat = pat;
    }
}
