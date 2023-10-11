using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    public GameObject Gplayer;
    public Transform gManager;
    private Vector3 position = Vector3.zero;
    private Vector3 offset = new Vector3(0, 4.3f, -10);
    private float xrange;
    private float yrange;
    float verticalSize;
    float horizontalSize;
    float offsetLast;
    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;
        verticalSize = mainCamera.orthographicSize;
        horizontalSize = verticalSize * mainCamera.aspect;
        offsetLast = ((gManager.gameObject.GetComponent<GameManager>().movingzone.y -1) / 2) -offset.y; 
        xrange = ((gManager.gameObject.GetComponent<GameManager>().movingzone.x)  / 2) - verticalSize + 2f;
        yrange = ((gManager.gameObject.GetComponent<GameManager>().movingzone.y)  / 2) - horizontalSize - 2.7f;

    }

    private void Start()
    {
        Debug.Log("xrange: " + xrange);
        Debug.Log("yrange: " + yrange);
        Debug.Log("offsetLast: " + offsetLast);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = camera_position();
    }

    public Vector3 camera_position()
    {
        position = Gplayer.transform.position;
        if (position.x < -xrange)
        {
            if (position.y < -offsetLast)
            {
                return new Vector3(-xrange, -yrange, -10);
            }
            else if (position.y > yrange - offset.y)
            {
                return new Vector3(-xrange, yrange, -10);
            }
            else
            {
                return new Vector3(-xrange, position.y, 0) + offset;
            }
        }
        else if (position.x > xrange)
        {
            if (position.y < -offsetLast)
            {
                return new Vector3(xrange, -yrange, -10);
            }
            else if (position.y > yrange - offset.y)
            {
                return new Vector3(xrange, yrange, -10);
            }
            else
            {
                return new Vector3(xrange, position.y, 0) + offset;
            }
        }
        else if (position.y < -offsetLast)
        {
            if (position.x < -xrange)
            {
                return new Vector3(-xrange, -yrange, 0) + offset;
            }
            else if (position.x > xrange)
            {
                return new Vector3(xrange, -yrange, 0) + offset;
            }
            else
            {
                return new Vector3(position.x, -yrange, -10);
            }

        }
        else if (position.y > yrange - offset.y)
        {

            if (position.x < -xrange)
            {
                return new Vector3(-xrange, yrange, 0) + offset;
            }
            else if (position.x > xrange)
            {
                return new Vector3(xrange, yrange, 0) + offset;
            }
            else
            {
                return new Vector3(position.x, yrange, -10);
            }
        }
        else
        {
            return position + offset;
        }

    }
}
