using System.Collections;
using UnityEngine;

public class MasterSparkShoot : MonoBehaviour
{
    public Transform[] spark;
    public float cooltime = 120;
    public Transform main_camera;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public float duration = 3.5f;

    Vector3 originalPos;

    void Start()
    {
        spark = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spark[i] = transform.GetChild(i);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            spark[i].gameObject.SetActive(false);
        }
        InvokeRepeating("Shoot", 2f, cooltime);
    }

    void Update()
    {
        // �� �κ��� �����Ͽ� ������ ��鸮�� ȿ���� �߰�
        main_camera.localPosition = Vector3.Lerp(main_camera.localPosition, originalPos, Time.deltaTime * decreaseFactor);
    }

    void DisablePlayerScript()
    {
        // ���� ��ü�� �θ� ã��
        Transform parentTransform = transform.parent;

        // �θ� ��ü�� �θ� ã��
        if (parentTransform != null)
        {
            Transform grandParentTransform = parentTransform.parent;

            // �θ� ��ü�� �θ��� �θ� ã��
            if (grandParentTransform != null)
            {
                Transform greatGrandParentTransform = grandParentTransform.parent;
                if (grandParentTransform != null)
                {
                    Transform greatgreatGrandParentTransform = grandParentTransform.parent;

                    // "Player" ��ũ��Ʈ�� �����ϴ��� Ȯ�� �� ��Ȱ��ȭ
                    Player playerScript = greatGrandParentTransform.GetComponent<Player>();
                    if (playerScript != null)
                    {
                        playerScript.enabled = false;
                    }
                }
            }
        }
    }

    void EnablePlayerScript()
    {
        // ���� ��ü�� �θ� ã��
        Transform parentTransform = transform.parent;

        // �θ� ��ü�� �θ� ã��
        if (parentTransform != null)
        {
            Transform grandParentTransform = parentTransform.parent;

            // �θ� ��ü�� �θ��� �θ� ã��
            if (grandParentTransform != null)
            {
                Transform greatGrandParentTransform = grandParentTransform.parent;
                if (grandParentTransform != null)
                {
                    Transform greatgreatGrandParentTransform = grandParentTransform.parent;

                    // "Player" ��ũ��Ʈ�� �����ϴ��� Ȯ�� �� ��Ȱ��ȭ
                    Player playerScript = greatGrandParentTransform.GetComponent<Player>();
                    if (playerScript != null)
                    {
                        playerScript.enabled = true;
                    }
                }
            }
        }
    }

    public void Shoot()
    {
        StartCoroutine(ShakeCamera());
        Invoke("StopShoot", duration);
        DisablePlayerScript();
        for (int i = 0; i < transform.childCount; i++)
        {
            spark[i].gameObject.SetActive(true);
        }
    }

    public void StopShoot()
    {
        EnablePlayerScript();
        for (int i = 0; i < transform.childCount; i++)
        {
            spark[i].gameObject.SetActive(false);
        }
    }

    IEnumerator ShakeCamera()
    {
        originalPos = main_camera.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            main_camera.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
