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
        // 초기 알파 값 설정
        SetAlpha(0f);

        // 특정 상황에서 알파 값 변경을 시작하도록 호출
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
                // 중간 타겟값에서 현재 색상값으로 갱신
                firstTargetColor = circleSR.color;

                // 나머지 10%의 시간동안 움직임
                Color middleTargetColor = originalColor;
                middleTargetColor.a = 0.9f;

                Tween moveTween = DOTween.To(() => circleSR.color, color => circleSR.color = color, middleTargetColor, (cooltime / 10) * 2 - 3)
                    .OnComplete(() =>
                    {
                        // 다시 중간 타겟값 갱신
                        middleTargetColor = circleSR.color;
                        Color finalTargetColor = originalColor;
                        firstTargetColor.a = 1f;

                        Tween finalTween = DOTween.To(() => circleSR.color, color => circleSR.color = color, middleTargetColor, 3)
                            .OnComplete(() =>
                            {
                                Debug.Log("아니 대체 왜?"); // 알파가 1이 되면 canshoot을 true로 설정
                            });
                    });
            });
        }
    }
    float GetAlpha()
    {
        // 현재 알파 값 반환
        return targetTransform.GetComponent<Renderer>().material.color.a;
    }

    void SetAlpha(float alpha)
    {
        // 알파 값 설정
        Color currentColor = targetTransform.GetComponent<Renderer>().material.color;
        targetTransform.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
    }
}