using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolClaer : MonoBehaviour
{
    public float interval = 0.8f; // 비활성화 간격 (초)

    private void Start()
    {
        InvokeRepeating("DeactivateChildren", 0f, interval);
    }

    private void DeactivateChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}




