using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 4.5f;
    private Vector3 position = Vector3.zero;
    private float H;
    private float V;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        position.x = H;
        position.y = V;
        position.z = 0f;
    }
    private void FixedUpdate()
    {
        transform.Translate(position * speed * Time.fixedDeltaTime);
    }
}
