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

    public int testspawnpoint;

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
        TestPlay();
    }

    public void TestPlay()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.1f);
        spawner.Spawn(0, 1, testspawnpoint);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Respawn());
    }
}
