using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float backgroundspeed = 10f;
    private Vector3 downVector = Vector3.down;
    public Transform removePoint;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += downVector * backgroundspeed * Time.deltaTime;
        float Yposition = transform.position.y;

        if (transform.position.y < removePoint.position.y)
        {
            transform.position = spawnPoint.position;
        }
    }
}
