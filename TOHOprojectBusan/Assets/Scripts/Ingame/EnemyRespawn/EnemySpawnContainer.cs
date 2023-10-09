using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct SpawnPatten
{
    //public string name;
    public int m_spawntime;  
    public int m_enemyid;
    public int m_spawnposid;
    public int m_movesequenceid;
    public bool m_spawnfilp;

    public SpawnPatten(int time, int enemyid, int spawnposid, int movesequenceid, bool flip)
    {
        //name = " ";
        m_spawntime = time;
        m_enemyid = enemyid;
        m_spawnposid = spawnposid;
        m_movesequenceid = movesequenceid;
        m_spawnfilp = flip;
    }
}
public class EnemySpawnContainer : MonoBehaviour
{
    public List<SpawnPatten> SpawnContainer;
  
    public void SetFileData(List<Dictionary<string, object>> data)
    {
        SpawnContainer.Clear();
        SpawnPatten spawnBuf;
        int time, enemyid, posid, seqid;
        bool filp;

        foreach (var Seq in data)
        {
            time = int.Parse(Seq["spawntime"].ToString());
            enemyid = int.Parse(Seq["enemyid"].ToString());
            posid = int.Parse(Seq["spawnposid"].ToString());
            seqid = int.Parse(Seq["movesequenceid"].ToString());

            if (int.Parse(Seq["spawnfilp"].ToString()) == 0)
                filp = false;
            else
                filp = true;

            spawnBuf = new SpawnPatten(time, enemyid, posid, seqid, filp);
            SpawnContainer.Add(spawnBuf);
        }
    }
}
