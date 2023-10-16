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
        // �ʱ� ���� ����
        Vector2 initialDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = initialDirection * initialSpeed;

        // 3�� �Ŀ� ���� �̵� ����
        StartCoroutine(StartRandomMovementAfterDelay(3f));
    }

    void Update()
    {
        if (!isMovingRandomly)
        {
            // �Ϲ����� �̵� ����
            // ���� ���, ������Ʈ�� Ư�� �������� ��� �̵��Ѵٰ� ����
            // �̵� ������ �ʿ信 ���� �����ϼ���
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

        // ������ �������� ���� �̵�
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = randomDirection * initialSpeed;

        yield return new WaitForSeconds(randomMoveDuration);

        // �ٽ� �Ϲ����� �̵� �������� ����
        Vector2 normalDirection = Vector2.right; // ���÷� ���������� �̵�
        GetComponent<Rigidbody2D>().velocity = normalDirection * initialSpeed;

        isMovingRandomly = false;
    }
}