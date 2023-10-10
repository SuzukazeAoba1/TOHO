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
        // 현재 크기
        Vector3 currentScale = transform.localScale;

        // 크기 감소
        currentScale -= new Vector3(shrinkSpeed, shrinkSpeed, 0f) * Time.deltaTime;

        // 최소 크기 이하로 작아지면 비활성화
        if (currentScale.x <= minSize && currentScale.y <= minSize)
        {
            gameObject.SetActive(false);
        }

        // 새로운 크기 적용
        transform.localScale = currentScale;
    }
}