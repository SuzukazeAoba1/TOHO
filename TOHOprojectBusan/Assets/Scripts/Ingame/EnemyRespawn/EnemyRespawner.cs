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
    private float spawnerPosX;
    private float spawnerPosY;


    public void Play()
    {
        TestPlay();
    }


    public void FileLoad()
    {

    }


    public void TestPlay()
    {
        spawnerPosY = (gameObject.GetComponent<GameManager>().spawnY);
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        GameObject buf;
        float testX = (gameObject.GetComponent<GameManager>().spawnX);
        spawnerPosX = Random.Range(-testX, testX);
        buf = Instantiate(gameObject.GetComponent<GameManager>().Enemy[0], new Vector3(spawnerPosX, spawnerPosY, 0), Quaternion.identity);
        buf.AddComponent<EnemyMovePatten>().Play();
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Respawn());
    }
}
