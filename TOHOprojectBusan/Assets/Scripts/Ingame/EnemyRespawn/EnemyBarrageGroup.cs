using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrageGroup : MonoBehaviour
{
    private float spd;

    public void SetSeq(float speed, float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        spd = speed;
    }
    void FixedUpdate()
    {
        transform.Translate(spd * Time.deltaTime * Vector2.up);
    }
}
