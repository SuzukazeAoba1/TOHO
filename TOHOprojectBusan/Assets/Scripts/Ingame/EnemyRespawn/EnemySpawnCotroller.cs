using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͸� �ڵ����� �����ϴ� Ŭ����
/// ������ 0���� ���� ��ȯ������ ���� ��ȣ�� ���� ���� �����ϰ� ���� ����
/// </summary>
/// <param name="lbl"></param>
public class EnemySpawnCotroller : MonoBehaviour
{
    public GameObject[] Enemy;
    private EnemySpawner spawner;
    private EnemyMovePatten movePatten;

    public int enemyid; //1

    [Range(1, 3)]
    public int spawnline; // 1~3

    [Range(1, 100)]
    public int spawnpos; // 1~100

    [Range(1, 3)]
    public int movepattenid; // 1~3

    public void Init(Vector2 movingzone)
    {
        spawner = gameObject.AddComponent<EnemySpawner>();
        movePatten = gameObject.AddComponent<EnemyMovePatten>();

        spawner.SetController(this);
        spawner.SetPatten(movePatten);
        spawner.SetZonePos(movingzone);
    }

    public void Play()
    {
        if (Enemy[0] != null)
        {
            TestPlay();
        }
    }

    public void TestPlay()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.1f);
        spawner.Spawn(enemyid - 1, ((spawnline - 1)*100) + spawnpos, movepattenid);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Respawn());
    }
}
