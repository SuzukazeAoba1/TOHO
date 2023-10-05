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
    private GameManager gameManager;
    private EnemySpawner enemySpawner;
    private float spawnerPosX;
    private float spawnerPosY;

    public void Start()
    {
        enemySpawner = gameObject.AddComponent<EnemySpawner>();
        gameManager = gameObject.GetComponent<GameManager>();
        enemySpawner.SetZonePos(gameManager.movingzone);
    }

    public void FileLoad()
    {

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
        enemySpawner.Spawn(0, 3, 0.5f);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Respawn());
    }
}
