using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumgiSummon : MonoBehaviour
{
    public Transform[] slashes;
    private int currentIndex = 0;
    public float cooLtime = 2f;
    public float delay = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        slashes = new Transform[transform.childCount];
        for (int i = 0; i<transform.childCount; i++)
        {
            slashes[i] = transform.GetChild(i);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            slashes[i].gameObject.SetActive(false);
        }

        InvokeRepeating("ActiveSlash", 0f, cooLtime);
    }

    // Update is called once per frame
    void ActiveSlash()
    {
        slashes[currentIndex].gameObject.SetActive(true);

        // ���� �ε����� �̵�
        currentIndex++;

        // ��� �ڽ� ������Ʈ�� �� ���� ���� �ε��� �ʱ�ȭ
        if (currentIndex >= slashes.Length)
        {
            currentIndex = 0;

        }
        else
        {
            Invoke("ActiveSlash", delay);
        }
    }
}
