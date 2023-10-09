using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MovePattenID
{
    Stop,
    LineMove,
    ToFast,
    ToSlow,
    ToSFS,
    DToFast,
    DToSlow,
    DToSFS,
    CurveA,
    CurveB
}

/// <summary>
/// ������ ���� ID�� �޾� ��ü�� �̵� �������� �����ؼ� ���̰� ��� ����ϴ� Ŭ����
/// </summary>
/// <param name="lbl"></param>
public class EnemyMoveController : MonoBehaviour
{
    private EnemyMoveContainer movepatten;
    private Vector2 zonesize;
    public void Moving(GameObject target, int moveid, bool flip)
    {
        Sequence seq = DOTween.Sequence().SetAutoKill(false); //�ݵ�� autokill�� ���ְ�, destroy���� ���� �ı��ؾ� ��
        MoveSequence mPatten = movepatten.Getpatten(moveid);

        Transform tr = target.transform;
        Vector3 nextPos = new Vector3(tr.position.x, tr.position.y);
        float moveX, moveY;

        for (int i = 0; i < mPatten.Seq.Count; i++)
        {
            moveX = mPatten.Seq[i].m_Pos.x * zonesize.x;
            moveY = mPatten.Seq[i].m_Pos.y * zonesize.x;

            if (flip) nextPos.x -= moveX;
            else      nextPos.x += moveX;

            nextPos.y += moveY;

            float length = new Vector2(moveX, moveY).magnitude;
            length = length / mPatten.Seq[i].m_spd;

            switch ((int)mPatten.Seq[i].m_pattenId)
            {
                case 0: seq.AppendInterval(mPatten.Seq[i].m_spd);                            break;
                case 1: seq.Append(tr.DOMove(nextPos, length).SetEase(Ease.Linear));       break;
                case 2: seq.Append(tr.DOMove(nextPos, length).SetEase(Ease.InSine));       break;
                case 3: seq.Append(tr.DOMove(nextPos, length).SetEase(Ease.OutSine));      break;
                case 4: seq.Append(tr.DOMove(nextPos, length).SetEase(Ease.InOutSine));    break;
                case 5: seq.Append(tr.DOMove(nextPos, length).SetEase(Ease.InQuad));       break;
                case 6: seq.Append(tr.DOMove(nextPos, length).SetEase(Ease.OutQuad));      break;
                case 7: seq.Append(tr.DOMove(nextPos, length).SetEase(Ease.InOutQuad));    break;
                case 8:
                    seq.Append(tr.DOMoveX(nextPos.x, length).SetEase(Ease.OutSine));
                    seq.Join(tr.DOMoveY(nextPos.y, length).SetEase(Ease.InSine));          break;
                case 9:
                    seq.Append(tr.DOMoveX(nextPos.x, length).SetEase(Ease.InSine));
                    seq.Join(tr.DOMoveY(nextPos.y, length).SetEase(Ease.OutSine));         break;
                case 101: break;
                //���� ������ join���� ��� �Ǵ� �̵��� ���ÿ�
                default: break;
            }
        }
        target.GetComponent<Enemy>().SetSequence(seq);
        seq.Play();

    }
    public void SetContainer(EnemyMoveContainer container)
    {
        movepatten = container;
    }

        public void SetZonePos(Vector2 movingzone)
    {
        zonesize.x = movingzone.x / 100.0f;
        zonesize.y = movingzone.y / 100.0f;
    }
}


