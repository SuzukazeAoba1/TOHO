using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MastersparkManager : MonoBehaviour
{
    public float speed = 1f;
    private float vspeed = 1f;
    private Vector3 RotateV = new Vector3(0, 0, -1);
    public float Cooltime = 150;
    private float cooltime = 120;
    public float duration = 3.5f;
    public Transform magicCircle;
    public Transform circleMove;
    private Vector3 save_position;
    private Vector3 save_scale;
    public GameObject Spark;
    public GameObject player;
    private SpriteRenderer circleSR;
    private Color originalColor;
    public bool canshoot = false;
    Tween fadeInTween;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Start()
    {
        cooltime = Cooltime;
        save_scale = magicCircle.transform.localScale;
        circleSR = magicCircle.GetComponent<SpriteRenderer>();
        originalColor = circleSR.color;
        vspeed = speed;
        StartShoot();
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
        magicCircle.position = save_position;
        circleMove.position = save_position + new Vector3(0, 1.62f, 0);
        canshoot = false;
        cooltime = Cooltime;
        moveMagicCircle();
        circleSR.sortingLayerName = "Default";
        Spark.GetComponent<MasterSparkShoot>().Shoot();
        vspeed = speed * 40;

    }
    private void StopSpark()
    {
        Spark.GetComponent<MasterSparkShoot>().StopShoot();
        vspeed = speed;
        cooltime = Cooltime;
        magicCircle.position = save_position;
        magicCircle.localScale = save_scale;
        Color startColor = originalColor;
        startColor.a = 0f;
        circleSR.sortingLayerName = "Foreground";
        circleSR.color = startColor;
        FadeInObject();
    }
    void FadeInObject()
    {
        // ������ 1���� ������ ����
        Color firstTargetColor = originalColor;
        firstTargetColor.a = 0.3f;

        fadeInTween = DOTween.To(() => circleSR.color, color => circleSR.color = color, firstTargetColor, (cooltime / 10) * 8)
            .OnComplete(() =>
            {
            // �߰� Ÿ�ٰ����� ���� �������� ����
            firstTargetColor = circleSR.color;

            // ������ 10%�� �ð����� ������
            Color middleTargetColor = originalColor;
                middleTargetColor.a = 0.9f;

                Tween moveTween = DOTween.To(() => circleSR.color, color => circleSR.color = color, middleTargetColor, (cooltime / 10) * 2 - 3)
                    .OnComplete(() =>
                    {
                    // �ٽ� �߰� Ÿ�ٰ� ����
                    middleTargetColor = circleSR.color;
                        Color finalTargetColor = originalColor;
                        firstTargetColor.a = 1f;

                        Tween finalTween = DOTween.To(() => circleSR.color, color => circleSR.color = color, middleTargetColor, 3)
                            .OnComplete(() =>
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
        StartCoroutine(ScaleMagicCircle());
        Vector3 targetPosition = player.transform.position + new Vector3(0, 1.62f, 0);

        // �̵� �ӵ�
        float moveSpeed = 6f;

        // �̵� �ð�
        float moveTime = 0.2f;

        // DOTween�� ����Ͽ� Ư�� �ð� ���� Ư�� ��ġ�� �̵�
        magicCircle.DOMove(targetPosition, moveTime).SetEase(Ease.Linear).SetSpeedBased().OnComplete(() =>
        {
            // �̵��� ������ ���⿡ �߰� �۾��� ������ �� �ֽ��ϴ�.
        });
    }

    IEnumerator ScaleMagicCircle()
    {
        Vector3 targetScale = new Vector3(2.1924f, 2.1924f, 2.1924f);
        float scaletime = 0.2f;

        // DOTween�� ����Ͽ� Ư�� �ð� ���� Ư�� ũ��� ������ ����
        magicCircle.DOScale(targetScale, scaletime).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            // ������ ������ ������ ���⿡ �߰� �۾��� ������ �� �ֽ��ϴ�.
        });

        yield return null;
    }

    public void cooltimego(float newCooltime)
    {
        Cooltime = newCooltime;
    }

    public void StartShoot()
    {
        canshoot = false;
        circleSR.color = originalColor;

        // 3�� �Ŀ� SparkShoot �޼��� ȣ��
        Invoke("SparkShoot", 3f);

        vspeed = speed * 12;
    }
}
