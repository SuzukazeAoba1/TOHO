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

        if (line == 1) //����
        {
            
            spawnpos.x = -(zoneX + 0.5f);
            spawnpos.y = (zoneY * loc * 2) - (zoneY);

        }
        else if (line == 2) //���
        {
            
            spawnpos.x = (zoneX * loc * 2) - (zoneX);
            spawnpos.y = (zoneY + 0.5f);
        }
        else if (line == 3) //������
        {
            
            spawnpos.x = (zoneX + 0.5f);
            spawnpos.y = -((zoneY * loc * 2) - (zoneY));
        }

        GameObject buf = Instantiate(gameManager.Enemy[enemyid], new Vector3(spawnpos.x, spawnpos.y, 0), Quaternion.identity);
        buf.AddComponent<EnemyMovePatten>().Play();

    }


}
