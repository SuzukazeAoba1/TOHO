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
        // 이 부분을 수정하여 서서히 흔들리는 효과를 추가
        main_camera.localPosition = Vector3.Lerp(main_camera.localPosition, originalPos, Time.deltaTime * decreaseFactor);
    }

    void DisablePlayerScript()
    {
        // 현재 개체의 부모 찾기
        Transform parentTransform = transform.parent;

        // 부모 개체의 부모 찾기
        if (parentTransform != null)
        {
            Transform grandParentTransform = parentTransform.parent;

            // 부모 개체의 부모의 부모 찾기
            if (grandParentTransform != null)
            {
                Transform greatGrandParentTransform = grandParentTransform.parent;
                if (grandParentTransform != null)
                {
                    Transform greatgreatGrandParentTransform = grandParentTransform.parent;

                    // "Player" 스크립트가 존재하는지 확인 후 비활성화
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
        // 현재 개체의 부모 찾기
        Transform parentTransform = transform.parent;

        // 부모 개체의 부모 찾기
        if (parentTransform != null)
        {
            Transform grandParentTransform = parentTransform.parent;

            // 부모 개체의 부모의 부모 찾기
            if (grandParentTransform != null)
            {
                Transform greatGrandParentTransform = grandParentTransform.parent;
                if (grandParentTransform != null)
                {
                    Transform greatgreatGrandParentTransform = grandParentTransform.parent;

                    // "Player" 스크립트가 존재하는지 확인 후 비활성화
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
