using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BarrageData
{
    //public string name;

    public int m_barrageid;
    public int m_angle;
    public int m_distance;
    public int m_basespeed;
    public int m_addspeed;
    public int m_delay;

    public BarrageData(int barrageid, int angle, int distance, int basespeed, int addspeed, int delay)
    {
        //name = " ";
        m_barrageid = barrageid;
        m_angle = angle;
        m_distance = distance;
        m_basespeed = basespeed;
        m_addspeed = addspeed;
        m_delay = delay;
    }
}

[Serializable]
public class BarragePatten
{
    public List<BarrageData> patten;

    public BarragePatten()
    {
        patten = new List<BarrageData>();
        patten.Clear();
    }
}

public class EnemyBarragePatten : MonoBehaviour
{
    public List<BarragePatten> List;

    public void SetFileData(List<Dictionary<string, object>> data)
    {
        List.Clear();
        BarrageData barragebuf;

        int pattenid, barrageid, angle, distance, basespeed, addspeed, delay;
        int currentid = 0;

        BarragePatten pattenbuf = new BarragePatten();
        
        List.Add(pattenbuf);

        foreach (var Seq in data)
        {
            pattenid = int.Parse(Seq["pattenid"].ToString());
            barrageid = int.Parse(Seq["barrageid"].ToString());
            angle = int.Parse(Seq["angle"].ToString());
            distance = int.Parse(Seq["distance"].ToString());
            basespeed = int.Parse(Seq["basespeed"].ToString());
            addspeed = int.Parse(Seq["addspeed"].ToString());
            delay = int.Parse(Seq["delay"].ToString());


            if(currentid < pattenid)
            {
                currentid = pattenid;
                pattenbuf = new BarragePatten();
                List.Add(pattenbuf);
            }

            barragebuf = new BarrageData(barrageid, angle, distance, basespeed, addspeed, delay);
            pattenbuf.patten.Add(barragebuf);
        }
    }
}
