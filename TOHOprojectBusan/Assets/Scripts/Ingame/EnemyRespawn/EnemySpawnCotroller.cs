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
