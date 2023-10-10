using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textsuicide : MonoBehaviour
{

    public float destroy_Time = 0.7f;
    public float shrinkSpeed = 0.4f;
    public float moveSpeed = 0.7f;
    public float minSize = 0.1f;
    private Vector3 setscale;
    TextMeshPro text;
    Color alpha;

    private void Awake()
    {
        setscale = transform.localScale;
    }
    private void OnEnable()
    {
        transform.localScale = setscale;
        Invoke("DeactivateSelf", destroy_Time);
        //alpha = text.color;
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, moveSpeed, Time.fixedDeltaTime));
    }

    private void Update()
    {
        Shrink();
        /*transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;*/

    }

    private void Shrink()
    {
        // ���� ũ��
        Vector3 currentScale = transform.localScale;

        // ũ�� ����
        currentScale -= new Vector3(shrinkSpeed, shrinkSpeed, 0f) * Time.deltaTime;

        // �ּ� ũ�� ���Ϸ� �۾����� ��Ȱ��ȭ
        if (currentScale.x <= minSize && currentScale.y <= minSize)
        {
            gameObject.SetActive(false);
        }

        // ���ο� ũ�� ����
        transform.localScale = currentScale;
    }
}