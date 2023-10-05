using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMYANGOK : MonoBehaviour
{
    public float damage;
    public int per;

    public void Onit(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }
}
