using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터를 자동으로 생성하는 클래스
/// 지금은 0번의 적만 소환하지만 추후 번호에 따라 선택 가능하게 변경 예정
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
            if (spawnpointid <= 100) //상단
            {
                spawnpos.x = (zoneX * ((spawnpointid - 0.5f) / 100.0f ) * 2) - (zoneX);
                spawnpos.y = (zoneY) + offset;
            }
            else if (spawnpointid <= 200) //왼쪽
            {
                spawnpointid = (spawnpointid - 100);

                spawnpos.x = -(zoneX) - offset;
                spawnpos.y = -((zoneY * ((spawnpointid - 0.5f) / 100.0f) * 2) - (zoneY));
            }
            else if (spawnpointid <= 300) //오른쪽
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
