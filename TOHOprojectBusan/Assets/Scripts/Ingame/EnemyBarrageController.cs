using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrageController : MonoBehaviour
{
    private BarrageContainer barragecon;
    private BarrageSequence barrageseq;
    private BarragePatten barragepat;

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
        //GameObject buf = Instantiate(barrageController.container[0], new Vector3(0, 30, 0), Quaternion.identity);
    }


    public void Setting(BarrageContainer con, BarrageSequence seq, BarragePatten pat)
    {
        barragecon = con;
        barrageseq = seq;
        barragepat = pat;
    }
}
