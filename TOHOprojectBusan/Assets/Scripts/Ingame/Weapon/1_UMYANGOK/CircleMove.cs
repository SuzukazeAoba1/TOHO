using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 RotateV = new Vector3(0, 0, -1);
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(RotateV, speed);
    }
}
