using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터를 자동으로 생성하는 클래스
/// 지금은 0번의 적만 소환하지만 추후 번호에 따라 선택 가능하게 변경 예정
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
