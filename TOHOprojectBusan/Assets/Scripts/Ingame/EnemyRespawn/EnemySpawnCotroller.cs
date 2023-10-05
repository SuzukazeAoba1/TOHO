using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터를 자동으로 생성하는 클래스
/// 지금은 0번의 적만 소환하지만 추후 번호에 따라 선택 가능하게 변경 예정
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
