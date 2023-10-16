using System.Collections;
using UnityEngine;

public class Moriyasoul : MonoBehaviour
{
    public Sprite[] sprites;
    public float initialSpeed = 5f;
    public float randomMoveDuration = 2f;
    public float rSpeed;
    private Vector3 rForce = new Vector3(0, 0, -1);
    public Transform main_camera;
    private bool isMovingRandomly = false;

    void Start()
    {
        // 초기 방향 설정
        Vector2 initialDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = initialDirection * initialSpeed;

    }

    void Update()
    {
        
        if (!isMovingRandomly)
        {
            moverandom();
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

        // 다시 일반적인 이동 방향으로 변경
        Vector2 normalDirection = Vector2.right; // 예시로 오른쪽으로 이동
        GetComponent<Rigidbody2D>().velocity = normalDirection * initialSpeed;

        isMovingRandomly = false;
    }

    
}