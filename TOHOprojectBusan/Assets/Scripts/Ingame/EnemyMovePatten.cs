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
    /// 적이 스폰 된 직후 움직이게 하는 함수, 추후 int 번호를 받아 고를 수 있게 제작할 예정
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
