using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct BarrageSequence
{
    //public string name;

    public int m_barragepattenid;
    public int m_basevector;
    public int m_shotnum;
    public int m_shotinterval;
    public int m_firstangle;
    public int m_perangle;

    public BarrageSequence(int barragepatten, int basevector, int shotnum, int shotinterval, int firstangle, int perangle)
    {
        //name = " ";
        m_barragepattenid = barragepatten;
        m_basevector = basevector;
        m_shotnum = shotnum;
        m_shotinterval = shotinterval;
        m_firstangle = firstangle;
        m_perangle = perangle;
    }
}
public class EnemyBarrageContainer : MonoBehaviour
{
    public List<BarrageSequence> List;

    public void SetFileData(List<Dictionary<string, object>> data)
    {

        List.Clear();
        BarrageSequence sequenceBuf;
        int pattenid, basevector, shotnum, shotinterval, firstangle, perangle;

        foreach (var Seq in data)
        {
            pattenid = int.Parse(Seq["barragepattenid"].ToString());
            basevector = int.Parse(Seq["basevector"].ToString());
            shotnum = int.Parse(Seq["shotnum"].ToString());
            shotinterval = int.Parse(Seq["shotinterval"].ToString());
            firstangle = int.Parse(Seq["firstangle"].ToString());
            perangle = int.Parse(Seq["perangle"].ToString());

            sequenceBuf = new BarrageSequence(pattenid, basevector, shotnum, shotinterval, firstangle, perangle);
            List.Add(sequenceBuf);
        }

    }
}
