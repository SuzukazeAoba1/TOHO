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
        // �ʱ� ���� ����
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

        // ������ �������� ���� �̵�
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = randomDirection * initialSpeed;
    }

    IEnumerator NoRandom()
    {
        

        yield return new WaitForSeconds(randomMoveDuration);

        // �ٽ� �Ϲ����� �̵� �������� ����
        Vector2 normalDirection = Vector2.right; // ���÷� ���������� �̵�
        GetComponent<Rigidbody2D>().velocity = normalDirection * initialSpeed;

        isMovingRandomly = false;
    }

    
}