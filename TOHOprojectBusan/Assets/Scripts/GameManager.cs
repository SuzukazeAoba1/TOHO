using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public float camerasize;
    public Vector2 movingzone;
    public Vector2 deathzone;

    public GameObject[] Enemy;
    public float spawnX;
    public float spawnY;

    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose);
        Init();
        Title();
    }

    private void Init()
    {
        // ���� ���ҽ� �ε��� ���� ��ũ��Ʈ
        gameObject.GetComponent<MainGame>().GamePlay();
    }

    private void Title()
    {
        //���� Ÿ��Ʋ UI ȭ���� ���� Ű���� �Է��� �޵��� ����
    }

    // Update is called once per frame
    void Update()
    {
        //Ű���� �Է��� ������ ���� ȭ�� ������ ��ȯ
    }

}
