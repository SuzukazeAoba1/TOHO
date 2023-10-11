using System.Collections;
using UnityEngine;

public class MasterSparkShoot : MonoBehaviour
{
    public GameObject Parent;
    public Transform[] spark;
    private float cooltime = 120;
    public Transform main_camera;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    private float duration = 3.5f;

    Vector3 originalPos;
    Vector3 playerlPos;

    private void Awake()
    {
        duration = Parent.GetComponent<MastersparkManager>().duration;
        cooltime = Parent.GetComponent<MastersparkManager>().cooltime;
    }
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
        //InvokeRepeating("Shoot", 2f, cooltime);
    }

    void Update()
    {
        
        // 이 부분을 수정하여 서서히 흔들리는 효과를 추가
        main_camera.localPosition = Vector3.Lerp(main_camera.localPosition, originalPos, Time.deltaTime * decreaseFactor);
    }

    private void FixedUpdate()
    {
        //playerlPos = main_camera.GetComponent<CameraController>().camera_position();
    }


    public void Shoot()
    {
        StartCoroutine(ShakeCamera());
        Invoke("StopShoot", duration);
        for (int i = 0; i < transform.childCount; i++)
        {
            spark[i].gameObject.SetActive(true);
        }
    }

    public void StopShoot()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spark[i].gameObject.SetActive(false);
        }
    }

    IEnumerator ShakeCamera()
    {
        //originalPos = main_camera.GetComponent<CameraController>().camera_position();

        float elapsed = 0f;

        while (elapsed < duration)
        {
            main_camera.localPosition = playerlPos + Random.insideUnitSphere * shakeAmount;

            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
