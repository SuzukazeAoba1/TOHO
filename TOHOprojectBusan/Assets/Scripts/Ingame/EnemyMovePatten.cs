using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovePatten : MonoBehaviour
{

    private void Update()
    {
        if(transform.position.y < -10)
        {
            transform.DOKill();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ���� ���� �� ���� �����̰� �ϴ� �Լ�, ���� int ��ȣ�� �޾� �� �� �ְ� ������ ����
    /// </summary>
    /// <param name="lbl"></param>
    public void Play()
    {
        Patten01();
    }

    private void Patten01()
    {
        transform.DOMoveY(-20, 7);
    }

}
