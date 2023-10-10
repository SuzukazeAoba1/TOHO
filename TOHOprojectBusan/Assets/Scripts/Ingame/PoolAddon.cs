using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAddon : MonoBehaviour
{
    public float interval = 20f; // 비활성화 간격 (초)
    public int previouSpawn = 20;
    private PoolManager myPool;

    private void Start()
    {
        myPool = GetComponent<PoolManager>();
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

    private void Update()
    {
        for(int i = 0; i == previouSpawn; i++)
        {
            for (int bullet = 0; bullet == myPool.prefabs.Length; bullet++)
            {
                myPool.Get(bullet);
            }
        }
    }
}




