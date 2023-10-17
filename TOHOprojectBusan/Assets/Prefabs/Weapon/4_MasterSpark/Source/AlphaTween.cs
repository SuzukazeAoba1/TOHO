using UnityEngine;
using DG.Tweening;

public class AlphaTween : MonoBehaviour
{
    public Transform targetTransform;
    public float cooltime = 120f;
    private SpriteRenderer circleSR;
    private Color originalColor;
    private Tween fadeInTween;
    private void Start()
    {
        circleSR = GetComponent<SpriteRenderer>();
        originalColor = circleSR.color;
        // �ʱ� ���� �� ����
        SetAlpha(0f);

        // Ư�� ��Ȳ���� ���� �� ������ �����ϵ��� ȣ��
        FadeInObject();
    }

    void FadeInObject()
    {
        Color firstTargetColor = originalColor;
        firstTargetColor.a = 0.3f;

        if (fadeInTween != null && fadeInTween.IsActive())
        {
            fadeInTween.Kill();
        }

        if (circleSR != null)
        {
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
                                Debug.Log("�ƴ� ��ü ��?"); // ���İ� 1�� �Ǹ� canshoot�� true�� ����
                            });
                    });
            });
        }
    }
    float GetAlpha()
    {
        // ���� ���� �� ��ȯ
        return targetTransform.GetComponent<Renderer>().material.color.a;
    }

    void SetAlpha(float alpha)
    {
        // ���� �� ����
        Color currentColor = targetTransform.GetComponent<Renderer>().material.color;
        targetTransform.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
    }
}