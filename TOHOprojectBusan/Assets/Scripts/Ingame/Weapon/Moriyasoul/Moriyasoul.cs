using System.Collections;
using UnityEngine;

public class Moriyasoul : MonoBehaviour
{
    public CameraController main_camera;
    public Transform player;
    public GameManager gManager;
    public Sprite[] sprites;
    public float initialSpeed = 5f;
    public float randomMoveDuration = 2f;
    public float rSpeed;
    private Vector3 rForce = new Vector3(0, 0, -1);
    private bool isMovingRandomly = false;
    private float xRange;
    private float yRange;

    private void Awake()
    {
        main_camera = Camera.main.GetComponent<CameraController>();

        //xRange = main_camera.camera_position().x + (main_camera.horizontalSize);
        //yRange = main_camera.camera_position().y + (main_camera.verticalSize);
        xRange = (gManager.gameObject.GetComponent<GameManager>().movingzone.x - 1) / 2;
        yRange = (gManager.gameObject.GetComponent<GameManager>().movingzone.y - 1) / 2;
    }
    void Start()
    {
        // 초기 방향 설정
        Vector2 initialDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = initialDirection * initialSpeed;

    }

    void Update()
    {
        xRange = main_camera.camera_position().x + (main_camera.horizontalSize);
        yRange = main_camera.camera_position().y + (main_camera.verticalSize);
        if (!isMovingRandomly)
        {
            moverandom();
        }
        if (transform.position.x <= -xRange)
        {
            StartCoroutine(NoRandom());
            isMovingRandomly = true;
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity + new Vector2(1,0);
            //isMovingRandomly = false;
            //transform.position = new Vector3(-xRange, transform.position.y, 0);
        }
        else if (transform.position.x >= xRange)
        {
            StartCoroutine(NoRandom());
            isMovingRandomly = true;
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity + new Vector2(-1, 0);
            //isMovingRandomly = false;
            //transform.position = new Vector3(xRange, transform.position.y, 0);
        }
        else if (transform.position.y <= -yRange)
        {
            StartCoroutine(NoRandom());
            isMovingRandomly = true;
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity + new Vector2(0, 1);
            //isMovingRandomly = false;
            //transform.position = new Vector3(transform.position.x, -yRange, 0);
        }
        else if (transform.position.y >= yRange)
        {
            StartCoroutine(NoRandom());
            isMovingRandomly = true;
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity + new Vector2(0, -1);
            //isMovingRandomly = false;
            //transform.position = new Vector3(transform.position.x, yRange, 0);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(rForce * rSpeed);
    }
    void moverandom()
    {
        StartCoroutine(NoRandom());
        isMovingRandomly = true;

        // 랜덤한 방향으로 선형 이동
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = randomDirection * initialSpeed;
    }

    IEnumerator NoRandom()
    {
        

        yield return new WaitForSeconds(randomMoveDuration);

        isMovingRandomly = false;
    }

    
}