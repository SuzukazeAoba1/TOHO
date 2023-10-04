using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destory : MonoBehaviour
{
    public float destroy_Time = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroy_Time);
    }
}
