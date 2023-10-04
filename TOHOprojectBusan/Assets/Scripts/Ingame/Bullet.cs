using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int ATK;
    public float Speed;
    public float destroy_Time;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroy_Time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
