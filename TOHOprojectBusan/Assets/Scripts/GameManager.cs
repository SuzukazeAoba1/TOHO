using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose);
        Init();
        Title();
    }

    private void Init()
    {
        // ���� ���ҽ� �ε��� ���� ��ũ��Ʈ
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
