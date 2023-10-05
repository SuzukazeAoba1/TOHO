using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Gplayer;
    private Vector3 position = Vector3.zero;
    private Vector3 offset = new Vector3(0, 4.3f, -10);
    private float xrange = 9.95f - 6f;
    private float yrange = 14.5f - 8.7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position = Gplayer.transform.position;
        if(position.x < -xrange)
        {
            if (position.y < -10.2f)
            {
                transform.position = new Vector3(-xrange, -yrange, -10);
            }
            else if (position.y > yrange - 4.3f)
            {
                transform.position = new Vector3(-xrange, yrange, -10);
            }
            else
            {
                transform.position = new Vector3(-xrange, position.y, 0) + offset;
            }
        }
        else if (position.x > xrange)
        {
            if(position.y < -10.2f)
            {
                transform.position = new Vector3(xrange, -yrange, -10);
            }
            else if(position.y > yrange - 4.3f)
            {
                transform.position = new Vector3(xrange, yrange, -10);
            }
            else
            {
                transform.position = new Vector3(xrange, position.y, 0) + offset;
            }
        }
        else if (position.y < -10.2f)
        {
            if(position.x < -xrange)
            {
                transform.position = new Vector3(-xrange, -yrange, 0) + offset;
            }
            else if(position.x > xrange)
            {
                transform.position = new Vector3(xrange, -yrange, 0) + offset;
            }
            else
            {
                transform.position = new Vector3(position.x, -yrange, -10);
            }
            
        }
        else if (position.y > yrange-4.3f)
        {

            if (position.x < -xrange)
            {
                transform.position = new Vector3(-xrange, yrange, 0) + offset;
            }
            else if (position.x > xrange)
            {
                transform.position = new Vector3(xrange, yrange, 0) + offset;
            }
            else
            {
                transform.position = new Vector3(position.x, yrange, -10);
            }
        }
        else
        {
            transform.position = position + offset;
        }
        
    }
}