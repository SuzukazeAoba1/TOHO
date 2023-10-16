using System.Collections;
using UnityEngine;

public class Moriyasoul : MonoBehaviour
{
    public float initialSpeed = 5f;
    public float randomMoveDuration = 2f;
    public Transform main_camera;
    private bool isMovingRandomly = false;

    void Start()
    {
        // 초기 방향 설정
        Vector2 initialDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = initialDirection * initialSpeed;

        // 3초 후에 랜덤 이동 시작
        StartCoroutine(StartRandomMovementAfterDelay(3f));
    }

    void Update()
    {
        if (!isMovingRandomly)
        {
            // 일반적인 이동 로직
            // 예를 들어, 오브젝트가 특정 방향으로 계속 이동한다고 가정
            // 이동 로직을 필요에 따라 수정하세요
        }
    }

    IEnumerator StartRandomMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveRandomly());
    }

    IEnumerator MoveRandomly()
    {
        isMovingRandomly = true;

        // 랜덤한 방향으로 선형 이동
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = randomDirection * initialSpeed;

        yield return new WaitForSeconds(randomMoveDuration);

        // 다시 일반적인 이동 방향으로 변경
        Vector2 normalDirection = Vector2.right; // 예시로 오른쪽으로 이동
        GetComponent<Rigidbody2D>().velocity = normalDirection * initialSpeed;

        isMovingRandomly = false;
    }
}