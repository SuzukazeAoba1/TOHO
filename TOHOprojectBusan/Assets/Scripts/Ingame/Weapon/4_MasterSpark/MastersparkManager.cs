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
            // 플레이어를 이름으로 찾아서 할당
            player = GameObject.FindWithTag("Player");

            // 찾지 못한 경우 에러 메시지 출력
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
        save_position = player.transform.position + new Vector3(0, 0, 0);
        circleMove.position = player.transform.position + new Vector3(0, 1.62f, 0);
        
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
        if(player.GetComponent<Player>().cheated == false)
        { player.GetComponent<Player>().Invincibility(duration); }
        
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
        // 투명도를 1까지 서서히 변경
        Color firsttargetColor = originalColor;
        firsttargetColor.a = 0.3f;

        LeanTween.value(gameObject, UpdateColor, circleSR.color, firsttargetColor, ((cooltime / 10) * 8))
            .setOnComplete(() =>
            {
                // 중간 타겟값에서 현재 색상값으로 갱신
                firsttargetColor = circleSR.color;

                // 나머지 10%의 시간동안 움직임
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
                                canshoot = true; // 알파가 1이 되면 canshoot을 true로 설정
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

        // 이동 속도
        float moveSpeed = 6f;

        // 이동 시간
        float moveTime = 0.2f;

        // LeanTween을 사용하여 특정 시간 동안 특정 위치로 이동
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
        LeanTween.cancel(gameObject); // 현재 게임 오브젝트에 대한 모든 LeanTween을 취소

        // circleSR의 알파값을 1로 설정
        Color finalColor = originalColor;
        finalColor.a = 1f;
        UpdateColor(finalColor);

        canshoot = true; // 알파가 1이 되면 canshoot을 true로 설정
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