using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrageController : MonoBehaviour
{
    EnemyBarrageContainer barrageController;

    public void SetContainer(EnemyBarrageContainer BarrageController)
    {
        barrageController = BarrageController;
    }
    public void Shoot(Transform enemypos, bool flip)
    {
        switch (0)
        {
            case 0:
                GameObject buf = Instantiate(barrageController.container[0], new Vector3(0, 30, 0), Quaternion.identity);
                break;
            default:
        }
    }
}
