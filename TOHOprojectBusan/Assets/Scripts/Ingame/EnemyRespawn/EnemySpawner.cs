using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터 생성을 담당하는 클래스
/// </summary>
/// <param name="lbl"></param>
public class EnemySpawner : MonoBehaviour
{
    private EnemyContainer enemyContainer;
    private EnemyMoveController moveController;

    private TestEnemySpawnController tspawnController;
    public GameObject SpawnerPosTest;

    private Vector2 spawnpos;
    private float offset = 0.5f;
    private float zoneX = 0;
    private float zoneY = 0;

    public void TestSpawn(int spawnpointid, int enemyid, int movepattenid, bool flip)
    {
        if (spawnpointid >= 0 && spawnpointid <= 120)
        {
            if (spawnpointid <= 50) //상단
            {
                spawnpos.x = (-zoneX * ((spawnpointid) / 50.0f));
                spawnpos.y = (zoneY) + offset;
            }
            else                    //왼쪽
            {
                spawnpointid = (spawnpointid - 50);

                spawnpos.x = (-zoneX) - offset;
                spawnpos.y = (zoneY) - ((zoneX * 2 * (spawnpointid / 50.0f)));
            }

            if (flip)
            {
                spawnpos.x = -spawnpos.x;
            }

            SpawnerPosTest.transform.position = new Vector3(spawnpos.x, spawnpos.y, 0);

            GameObject buf = Instantiate(tspawnController.TestEnemy[enemyid], new Vector3(spawnpos.x, spawnpos.y, 0), Quaternion.identity);
            buf.GetComponent<Enemy>().test = true;
            moveController.Moving(buf, movepattenid, flip);
        }
    }

    /// <summary>
    /// 몬스터 id를 입력받아 해당 위치에 몬스터 오브젝트를 생성하고 이동 패턴을 붙여주는 메소드
    /// </summary>
    public GameObject Spawn(int spawnpointid, int enemyid, int movesequenceid, bool flip)
    {
        if (spawnpointid >= 0 && spawnpointid <= 120)
        {
            if (spawnpointid <= 50) //상단
            {
                spawnpos.x = (-zoneX * ((spawnpointid) / 50.0f));
                spawnpos.y = (zoneY) + offset;
            }
            else                    //왼쪽
            {
                spawnpointid = (spawnpointid - 50);

                spawnpos.x = (-zoneX) - offset;
                spawnpos.y = (zoneY) - ((zoneX * 2 * (spawnpointid / 50.0f)));
            }

            if(flip)
            {
                spawnpos.x = -spawnpos.x;
            }

            SpawnerPosTest.transform.position = new Vector3(spawnpos.x, spawnpos.y, 0);

            GameObject buf = Instantiate(enemyContainer.container[enemyid], new Vector3(spawnpos.x, spawnpos.y, 0), Quaternion.identity);

            moveController.Moving(buf, movesequenceid, flip);
            return buf;
        }
        return null;
    }

    public void SetTestController(TestEnemySpawnController con)
    {
        tspawnController = con;
        SpawnerPosTest = gameObject;
    }

    public void SetContainer(EnemyContainer econ)
    {
        enemyContainer = econ;
    }

    public void SetMoveController(EnemyMoveController con)
    {
        moveController = con;
    }

    public void SetZonePos(Vector2 movingzone)
    {
        zoneX = movingzone.x / 2;
        zoneY = movingzone.y / 2;
    }

}
