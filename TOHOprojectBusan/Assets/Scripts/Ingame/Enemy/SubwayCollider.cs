using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayCollider : MonoBehaviour
{
    private BoxCollider2D myCollider;
    public float comeoffsetx = 49.704f;
    public float comesizex = 100.41f;
    public float outoffsetx = 99.183f;
    public float outsizex = 1f;
    public float duration = 0.6f;
    // Start is called before the first frame update
    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        StartCoroutine(Out());
        Getsize(comeoffsetx, comesizex, duration);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Getsize(float targetOffset, float targetSize, float duration)
    {
        // offset ��ȭ
        LeanTween.value(gameObject, UpdateOffset, myCollider.offset.x, targetOffset, duration);

        // size ��ȭ
        LeanTween.value(gameObject, UpdateSize, myCollider.size.x, targetSize, duration);
    }

    // LeanTween���� ����� �Լ��� offset�� ������Ʈ
    private void UpdateOffset(float value)
    {
        Vector2 currentOffset = myCollider.offset;
        currentOffset.x = value;
        myCollider.offset = currentOffset;
    }

    // LeanTween���� ����� �Լ��� size�� ������Ʈ
    private void UpdateSize(float value)
    {
        Vector2 currentSize = myCollider.size;
        currentSize.x = value;
        myCollider.size = currentSize;
    }

    IEnumerator Out()
    {
        yield return new WaitForSeconds(2f);
        Getsize(outoffsetx, outsizex, duration);
    }
}
