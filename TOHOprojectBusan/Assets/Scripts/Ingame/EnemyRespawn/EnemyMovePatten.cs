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

        switch(pattennum)
        {
            case 1:
                moveTarget.DOMoveY(moveTarget.position.y - 50, 5);
                break;
            case 2:
                moveTarget.DOMoveX(moveTarget.position.x + 50, 5);
                break;
            case 3:
                moveTarget.DOMoveX(moveTarget.position.x - 50, 5);
                break;
            default:
                break;
                
        }
    }
}
