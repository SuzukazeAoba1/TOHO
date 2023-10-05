using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͸� �ڵ����� �����ϴ� Ŭ����
/// ������ 0���� ���� ��ȯ������ ���� ��ȣ�� ���� ���� �����ϰ� ���� ����
/// </summary>
/// <param name="lbl"></param>
public class EnemySpawner : MonoBehaviour
{
    private EnemySpawnCotroller controller;
    private EnemyMovePatten movePatten;
    private Vector2 spawnpos;

    private float offset = 0.5f;
    private float zoneX = 0;
    private float zoneY = 0;

    public void SetController(EnemySpawnCotroller con)
    {
        controller = con;
    }

    public void SetPatten(EnemyMovePatten move)
    {
        movePatten = move;
    }

    public void SetZonePos(Vector2 movingzone)
    {
        zoneX = movingzone.x / 2;
        zoneY = movingzone.y / 2;
    }

    public void Spawn(int enemyid, int spawnpointid, int moveid)
    {
        //spawn line(1~30)
        if (spawnpointid > 0 && spawnpointid < 301)
        {
            if (spawnpointid <= 100) //���
            {
                spawnpos.x = (zoneX * ((spawnpointid - 0.5f) / 100.0f ) * 2) - (zoneX);
                spawnpos.y = (zoneY) + offset;
            }
            else if (spawnpointid <= 200) //����
            {
                spawnpointid = (spawnpointid - 100);

                spawnpos.x = -(zoneX) - offset;
                spawnpos.y = -((zoneY * ((spawnpointid - 0.5f) / 100.0f) * 2) - (zoneY));
            }
            else if (spawnpointid <= 300) //������
            {
                spawnpointid = (spawnpointid - 200);

                spawnpos.x = (zoneX) + offset;
                spawnpos.y = -((zoneY * ((spawnpointid - 0.5f) / 100.0f) * 2) - (zoneY));
            }

            GameObject buf;
            buf = Instantiate(controller.Enemy[enemyid], new Vector3(spawnpos.x, spawnpos.y, 0), Quaternion.identity);
            movePatten.Moving(buf, moveid);
        }
    }


}
