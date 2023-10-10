using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct BarragePatten
{
    //public string name;

    public int m_id;
    public int m_middistance;
    public int m_angle;
    public int m_speed;

    public BarragePatten(int id, int middistance, int angle, int speed)
    {
        //name = " ";
        m_id = id;
        m_middistance = middistance;
        m_angle = angle;
        m_speed = speed;
    }
}

public class EnemyBarragePatten : MonoBehaviour
{
    public List<BarragePatten> List;

    public void SetFileData(List<Dictionary<string, object>> data)
    {
        List.Clear();
        BarragePatten spawnBuf;
        int id, middistance, angle, speed;

        foreach (var Seq in data)
        {
            id = int.Parse(Seq["barrageid"].ToString());
            middistance = int.Parse(Seq["middistance"].ToString());
            angle = int.Parse(Seq["angle"].ToString());
            speed = int.Parse(Seq["basespeed"].ToString());


            spawnBuf = new BarragePatten(id, middistance, angle, speed);
            List.Add(spawnBuf);
        }
    }
}
