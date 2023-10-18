using System.Collections;
using UnityEngine;

public class MoriyaMove : MonoBehaviour
{
    public CameraController main_camera;
    public Transform player;
    public GameManager gManager;
    public Sprite[] sprites;
    public float initialSpeed = 5f;
    public float randomMoveDuration = 2f;
    public float rSpeed;
    private float spinning;
    private Vector3 rForce = new Vector3(0, 0, -1);
    private bool isMovingRandomly = false;
    public bool isAlive;

    private void Awake()
    {
        spinning = rSpeed;
        main_camera = Camera.main.GetComponent<CameraController>();
        isAlive = true;
    }

    void Start()
    {
        // 초기 방향 설정
        Vector2 initialDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = initialDirection * initialSpeed;
    }

    void Update()
    {
        if(isAlive)
        {
            if (!isMovingRandomly)
            {
                moverandom();
            }

            // 현재 카메라의 위치 및 크기 정보 가져오기
            Vector3 cameraPosition = main_camera.camera_position();
            float xRange = main_camera.horizontalSize - 2.0f;
            float yRange = main_camera.verticalSize - 2.0f;

            // 카메라 내부에서만 움직이도록 제한
            float clampedX = Mathf.Clamp(transform.position.x, cameraPosition.x - xRange, cameraPosition.x + xRange);
            float clampedY = Mathf.Clamp(transform.position.y, cameraPosition.y - yRange, cameraPosition.y + yRange);
  

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }

        
    }

    private void FixedUpdate()
    {
            transform.Rotate(rForce * spinning);
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

    public void Die()
    {
        spinning = 0f;
        GetComponent<SpriteRenderer>().sprite = sprites[1];
        //GetComponent<CircleCollider2D>().isTrigger = true;
        GetComponent<CircleCollider2D>().radius = GetComponent<CircleCollider2D>().radius = 2.3f;
        gameObject.layer = 9;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isAlive = false;
    }

    public void Resurection()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        //GetComponent<CircleCollider2D>().isTrigger = false;
        GetComponent<CircleCollider2D>().radius = GetComponent<CircleCollider2D>().radius = 4.9f;
        gameObject.layer = 6;
        isAlive = true;
        spinning = rSpeed;
    }

}
