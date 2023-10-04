using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͸� �ڵ����� �����ϴ� Ŭ����
/// ������ 0���� ���� ��ȯ������ ���� ��ȣ�� ���� ���� �����ϰ� ���� ����
/// </summary>
/// <param name="lbl"></param>
public class EnemyRespawner : MonoBehaviour
{
    public GameObject[] Enemy;

    public float spawnX;
    public float spawnY;

    private float spawnerPosX;
    private float spawnerPosY;

    void Start()
    {
        spawnerPosY = spawnY;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        GameObject buf;
        spawnerPosX = Random.Range(-spawnX, spawnX);
        buf = Instantiate(Enemy[0], new Vector3(spawnerPosX, spawnerPosY, 0), Quaternion.identity);
        buf.AddComponent<EnemyMovePatten>().Play();
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Respawn());
    }
}
