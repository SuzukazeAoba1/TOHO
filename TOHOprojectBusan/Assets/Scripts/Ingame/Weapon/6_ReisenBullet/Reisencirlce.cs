using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reisencirlce : MonoBehaviour
{
    public float rForce = 1f;
    private Vector3 rVector = new Vector3(0, 0, -1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GetComponent<Transform>().Rotate(rVector * rForce);
    }

}
