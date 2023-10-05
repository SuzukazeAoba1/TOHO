using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovePatten : MonoBehaviour
{
    Transform moveTarget;

    public void Moving(GameObject target, int pattennum)
    {
        moveTarget = target.transform;

        if (pattennum == 1)
        {
            Patten01();
        }
        if (pattennum == 2)
        {
            Patten02();
        }
    }

    private void Patten01()
    {
        moveTarget.DOMoveY(moveTarget.position.y - 50, 7);
    }

    private void Patten02()
    {
        moveTarget.DOMoveX(moveTarget.position.x + 50, 7);
    }

}
