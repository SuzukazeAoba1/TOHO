using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MovePatten
{
    public string name;
    public MovePattenID m_pattenId;     //움직임 id
    [Range(1f, 20f)]
    public float m_spd;          //이동 속도
    public Vector2 m_Pos;         //이동 위치

    public MovePatten(float speed, int movepattenid)
    {
        name = " ";
        m_pattenId = (MovePattenID)movepattenid;
        m_spd = speed;
        m_Pos = Vector2.zero;
    }

    public MovePatten(float speed, int movepattenid, Vector2 movePos)
    {
        name = " ";
        m_pattenId = (MovePattenID)movepattenid;
        m_spd = speed;
        m_Pos = movePos;
    }
}

[Serializable]
public class MoveSequence
{
    public List<MovePatten> Seq;
    public MoveSequence()
    {
        Seq = new List<MovePatten>();
    }
}

[Serializable]
public class MoveSequenceList
{
    public List<MoveSequence> List;

    public MoveSequenceList()
    {
        List = new List<MoveSequence>();
    }
}

public class EnemyMoveContainer : MonoBehaviour
{
    public MoveSequenceList SequenceList; // 모든 패턴을 담은 구조체

    public void SetFileData(List<Dictionary<string, object>> data)
    {
        SequenceList = new MoveSequenceList();
        SequenceList.List.Clear();

        MoveSequence sequencebuf = new MoveSequence();

        int sequenceid = 0;
        int lineid, dur, pat;
        float x, y;

        foreach (var Seq in data)
        {
            lineid  = int.Parse(Seq["sequenceid"].ToString());
            dur     = int.Parse(Seq["speed"].ToString());
            pat     = int.Parse(Seq["pattenid"].ToString());
            x       = int.Parse(Seq["posx"].ToString());
            y       = int.Parse(Seq["posy"].ToString());

            if (sequenceid < lineid)
            {
                SequenceList.List.Add(sequencebuf);
                sequencebuf = new MoveSequence();
                sequenceid++;
            }

            sequencebuf.Seq.Add(new MovePatten(dur, pat, new Vector2(x, y)));

        }

        SequenceList.List.Add(sequencebuf);
    }
    public void SetTestData()
    {
        SequenceList = new MoveSequenceList();
        SequenceList.List.Clear();

        MoveSequence TestSequence = new MoveSequence(); //이게 시퀀스 패턴 하나

        TestSequence.Seq.Add(new MovePatten(10, 1, new Vector2(50f, -50f)));
        TestSequence.Seq.Add(new MovePatten(10, 2, new Vector2(-50f, -50f)));
        TestSequence.Seq.Add(new MovePatten(10, 3, new Vector2(-50f, 50f)));
        TestSequence.Seq.Add(new MovePatten(10, 4, new Vector2(50f, 50f)));

        SequenceList.List.Add(TestSequence);
    }

    public MoveSequence Getpatten(int movepattenid)
    {
        return SequenceList.List[movepattenid];
    }

   
}
