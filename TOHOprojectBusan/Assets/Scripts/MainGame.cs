using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private EnemySpawnCotroller spawner;

    public float camerasize;
    public Vector2 movingzone;
    public Vector2 deathzone;

    void Start()
    {
        spawner = GetComponent<EnemySpawnCotroller>();
        spawner.Init(movingzone);
        spawner.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾� �Է� ��� ��ȯ
        //�� ���� ��� �۵�
        //���� �ڵ� ���� ��� �۵�
    }

    /// <summary>
    /// ������ ������ �� �θ��� �Լ�, ������Ʈ ����� ����
    /// </summary>
    /// <param name="lbl"></param>
    public void GamePlay()
    {
        

        //���� �ʱ�ȭ, ���� �÷��̾� ����
        //�� ���� ����ġ Ȱ��ȭ
        //���� ���� ���� ����ġ Ȱ��ȭ
    }

    /// <summary>
    /// ���� ������ ���߰� ���� ���� UI ȭ���� �Ѵ� �Լ�    
    /// </summary>
    /// <param name="lbl"></param>
    public void GameOver()
    {
 
    }

    /// <summary>
    /// ���� ������ ���߰� Ŭ���� UI ȭ�� �Ѵ� �Լ� 
    /// </summary>
    /// <param name="lbl"></param>
    public void GameClear()
    {
        
    }


}
