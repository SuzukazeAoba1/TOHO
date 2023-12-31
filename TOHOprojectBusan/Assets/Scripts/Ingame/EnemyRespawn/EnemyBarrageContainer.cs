using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BarrageSequence
{
    //public string name;

    public int m_barragepattenid;
    public int m_shotnum;
    public int m_basevector;
    public float m_shotfirst;
    public float m_shotinterval;
    public float m_shotlooptime;
    public int m_firstangle;
    public int m_perangle;
    public bool m_target;

    public BarrageSequence(int barragepatten, int shotnum, int shotfirst, int shotinterval, int shotlooptime,  int basevector, int firstangle, int perangle, int target)
    {
        //name = " ";
        m_barragepattenid = barragepatten;
        m_shotnum = shotnum;
        m_shotfirst = shotfirst / 10.0f;
        m_shotinterval = shotinterval / 60.0f;
        m_shotlooptime = shotlooptime / 10.0f;
        m_basevector = basevector;
        m_firstangle = firstangle;
        m_perangle = perangle;

        if (target == 0) m_target = false;
        else             m_target = true;
    }
}
public class EnemyBarrageContainer : MonoBehaviour
{
    public List<BarrageSequence> List;

    public void SetFileData(List<Dictionary<string, object>> data)
    {
        List = new List<BarrageSequence>();
        List.Clear();
        BarrageSequence sequenceBuf;
        int pattenid, shotnum, shotfirst, shotinterval, shotlooptime, basevector, firstangle, perangle, target;

        foreach (var Seq in data)
        {
            pattenid = int.Parse(Seq["barragepattenid"].ToString()); 
            shotnum = int.Parse(Seq["shotnum"].ToString());
            shotfirst = int.Parse(Seq["shotfirst"].ToString());
            shotinterval = int.Parse(Seq["shotinterval"].ToString());
            shotlooptime = int.Parse(Seq["shotlooptime"].ToString());
            basevector = int.Parse(Seq["basevector"].ToString());
            firstangle = int.Parse(Seq["firstangle"].ToString());
            perangle = int.Parse(Seq["perangle"].ToString());
            target = int.Parse(Seq["target"].ToString());

            sequenceBuf = new BarrageSequence(pattenid, shotnum, shotfirst, shotinterval, shotlooptime, basevector, firstangle, perangle, target);
            List.Add(sequenceBuf);
        }

    }
}
