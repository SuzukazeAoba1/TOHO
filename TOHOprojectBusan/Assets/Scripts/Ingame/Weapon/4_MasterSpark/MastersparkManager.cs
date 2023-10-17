using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastersparkManager : MonoBehaviour
{
    public float speed = 10f;
    private float vspeed = 10f;
    private Vector3 RotateV = new Vector3(0, 0, -1);
    public float set_cooltime = 120;
    private float cooltime = 120;
    public float duration = 3.5f;
    public Transform magicCircle;
    public Transform circleMove;
    private Vector3 save_position;
    private Vector3 save_scale;
    public GameObject Spark;
    public GameObject player;
    public Backgroundaudio bgm;
    public AudioSource volume;
    private float save_volume;
    private SpriteRenderer circleSR;
    private Color originalColor;
    private bool canshoot = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if (player == null)
        {
            // �÷��̾ �̸����� ã�Ƽ� �Ҵ�
            player = GameObject.FindWithTag("Player");

            // ã�� ���� ��� ���� �޽��� ���
            if (player == null)
            {
                Debug.LogError("Player not found!");
            }
        }
        bgm = FindObjectOfType<Backgroundaudio>();
        volume = bgm.GetComponent<AudioSource>();
        save_volume = volume.volume;
        cooltime = set_cooltime;
        save_position = player.transform.position + new Vector3(0, 0, 0);
        circleMove.position = player.transform.position + new Vector3(0, 1.62f, 0);
        save_scale = magicCircle.transform.localScale;
        circleSR = magicCircle.GetComponent<SpriteRenderer>();
        originalColor = circleSR.color;
        vspeed = speed;
    }
    void Start()
    {
        Invoke("CanShoot", 3f);
        vspeed = speed * 12;

    }
    private void OnEnable()
    {
        //save_position = player.transform.position + new Vector3(0, 0, 0);
        //circleMove.position = player.transform.position + new Vector3(0, 1.62f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canshoot)
        {
            SparkShoot();
        }
    }

    private void FixedUpdate()
    {
        save_position = player.transform.position + new Vector3(0, 0, 0);
        circleMove.position = player.transform.position + new Vector3(0, 1.62f, 0);
        magicCircle.transform.Rotate(RotateV, vspeed);
    }

    private void SparkShoot()
    {
        Invoke("StopSpark", duration);
        canshoot = false;
        moveMagicCircle();
        circleSR.sortingLayerName = "Default";
        HideVolume();


        Spark.GetComponent<MasterSparkShoot>().Shoot();
        vspeed = speed * 40;

    }
    private void StopSpark()
    {
        Spark.GetComponent<MasterSparkShoot>().StopShoot();
        vspeed = speed;
        cooltime = set_cooltime;
        magicCircle.position = save_position;
        magicCircle.localScale = save_scale;
        StartCoroutine(RetoreVolume());
        Color startColor = originalColor;
        startColor.a = 0f;
        circleSR.sortingLayerName = "Foreground";
        circleSR.color = startColor;
        FadeInObject();
    }
    void FadeInObject()
    {
        // ������ 1���� ������ ����
        Color firsttargetColor = originalColor;
        firsttargetColor.a = 0.3f;

        LeanTween.value(gameObject, UpdateColor, circleSR.color, firsttargetColor, ((cooltime / 10) * 8))
            .setOnComplete(() =>
            {
                // �߰� Ÿ�ٰ����� ���� �������� ����
                firsttargetColor = circleSR.color;

                // ������ 10%�� �ð����� ������
                Color middleTargetColor = originalColor;

                middleTargetColor.a = 0.9f;
                vspeed = speed * 3;
                LeanTween.value(gameObject, UpdateColor, firsttargetColor, middleTargetColor, ((cooltime / 10) * 2) - 3)
                    .setOnComplete(() =>
                    {
                        middleTargetColor = circleSR.color;
                        Color finalTargetColor = originalColor;
                        firsttargetColor.a = 1f;
                        vspeed = speed * 12;
                        LeanTween.value(gameObject, UpdateColor, middleTargetColor, middleTargetColor, 3)
                            .setOnComplete(() =>
                            {
                                canshoot = true; // ���İ� 1�� �Ǹ� canshoot�� true�� ����
                            });

                    });
            });
    }
    void UpdateColor(Color color)
    {
        circleSR.color = color;
    }

    void moveMagicCircle()
    {
        StartCoroutine("ScaleMagicCircle");
        Vector3 targetPosition = circleMove.position;

        // �̵� �ӵ�
        float moveSpeed = 6f;

        // �̵� �ð�
        float moveTime = 0.2f;

        // LeanTween�� ����Ͽ� Ư�� �ð� ���� Ư�� ��ġ�� �̵�
        LeanTween.move(magicCircle.gameObject, targetPosition, moveTime).setEase(LeanTweenType.linear).setSpeed(moveSpeed);

    }

    IEnumerator ScaleMagicCircle()
    {
        Vector3 targetScale = new Vector3(2.1924f, 2.1924f, 2.1924f);
        float scaletime = 0.2f;
        LeanTween.scale(magicCircle.gameObject, targetScale, scaletime)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() => { });
        yield return null;
    }

    void CancelFadeAndSetAlphaToOne()
    {
        LeanTween.cancel(gameObject); // ���� ���� ������Ʈ�� ���� ��� LeanTween�� ���

        // circleSR�� ���İ��� 1�� ����
        Color finalColor = originalColor;
        finalColor.a = 1f;
        UpdateColor(finalColor);

        canshoot = true; // ���İ� 1�� �Ǹ� canshoot�� true�� ����
    }

    public void StartShoot()
    {
        CancelFadeAndSetAlphaToOne();
        canshoot = false;
        Invoke("CanShoot", 3f);
        vspeed = speed * 12;

    }

    void CanShoot()
    {
        canshoot = true;
    }
    void HideVolume()
    {
        LeanTween.value(gameObject, SetVolume, volume.volume, 0.018f, 0.4f)
           .setOnComplete(() =>
           {

           });
    }
    void RestoreVolumeset()
    {
        LeanTween.value(gameObject, SetVolume, volume.volume, save_volume, 1.2f)
            .setOnComplete(() =>
            {
            });
    }

    private void SetVolume(float nvoluem)
    {
        volume.volume = nvoluem;
    }

    IEnumerator RetoreVolume()
    {
        yield return new WaitForSeconds(1.2f);

        RestoreVolumeset();
    }
}