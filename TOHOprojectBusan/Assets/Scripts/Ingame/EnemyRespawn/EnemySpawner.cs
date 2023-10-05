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
    private GameManager gameManager; //test
    private Vector2 spawnpos;
    private float zoneX = 0;
    private float zoneY = 0;

    public void SetZonePos(Vector2 movingzone)
    {
        gameManager = gameObject.GetComponent<GameManager>();

        zoneX = movingzone.x / 2;
        zoneY = movingzone.y / 2;
    }

    public void Spawn(int enemyid, int line, float loc)
    {
        //spawn line(1,2,3) loc (0~1)

        if (line == 1) //왼쪽
        {
            
            spawnpos.x = -(zoneX + 0.5f);
            spawnpos.y = (zoneY * loc * 2) - (zoneY);

        }
        else if (line == 2) //상단
        {
            
            spawnpos.x = (zoneX * loc * 2) - (zoneX);
            spawnpos.y = (zoneY + 0.5f);
        }
        else if (line == 3) //오른쪽
        {
            
            spawnpos.x = (zoneX + 0.5f);
            spawnpos.y = -((zoneY * loc * 2) - (zoneY));
        }

        GameObject buf = Instantiate(gameManager.Enemy[enemyid], new Vector3(spawnpos.x, spawnpos.y, 0), Quaternion.identity);
        buf.AddComponent<EnemyMovePatten>().Play();

    }


}
