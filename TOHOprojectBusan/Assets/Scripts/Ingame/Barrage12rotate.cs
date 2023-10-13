using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage12rotate : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform TR;
    private float speed = 60.0f;
    private Vector3 myVector = new Vector3(0, 0, -1);
    void Start()
    {
        TR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        TR.Rotate(myVector * speed * Time.deltaTime);
    }
}
