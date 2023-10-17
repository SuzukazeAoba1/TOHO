using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    public GameObject Gplayer;
    public Transform gManager;
    private Vector3 position = Vector3.zero;
    private Vector3 offset = new Vector3(0, 4f, -10);
    public float xrange;
    public float yrange;
    public float verticalSize;
    public float horizontalSize;
    float offsetLast;
    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;

        verticalSize = mainCamera.orthographicSize;
        horizontalSize = verticalSize * mainCamera.aspect;

        offsetLast = ((gManager.gameObject.GetComponent<GameManager>().movingzone.y) / 2) -offset.y + 0.5f;
        xrange = ((gManager.gameObject.GetComponent<GameManager>().movingzone.x)  / 2) - verticalSize + 2f;
        //yrange = ((gManager.gameObject.GetComponent<GameManager>().movingzone.y)  / 2) - horizontalSize - 0.5f;

        //xrange = ((gManager.gameObject.GetComponent<GameManager>().movingzone.x) / 2.0f);
        yrange = ((gManager.gameObject.GetComponent<GameManager>().movingzone.y) / 2.0f);
    }

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.position = camera_position2();
    }

    public Vector3 camera_position2()
    {
        position = Gplayer.transform.position;

        float posx, posy, posz;

        if (position.x < -xrange)
        {
            posx = -xrange;
        }
        else if (position.x > xrange)
        {
            posx = xrange;
        }
        else
        {
            posx = position.x;
        }

        //posx = position.x - (position.x / xrange) * (verticalSize - 2.5f);
        posy = position.y - (position.y / yrange) * (horizontalSize - 1.0f);
        posz = -10.0f;

        Debug.Log(verticalSize + " " + horizontalSize);

        return new Vector3(posx, posy, posz);
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
