using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    private EnemySpawnController spawncontroller;

    public float camerasize;
    public Vector2 movingzone;
    public Vector2 deathzone;

    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose);
        DOTween.SetTweensCapacity(5000, 500); //�ΰ��ӿ��� �����̴� ��ü ���� �ִ� 500��
        DOTween.defaultAutoKill = false;
        DOTween.defaultAutoPlay = AutoPlay.None;

        spawncontroller = GetComponent<EnemySpawnController>();
        spawncontroller.Init(movingzone);
        //spawncontroller.Play();
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
