using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotGui : MonoBehaviour
{
    Text textlevel;
    Text textdesc2;
    public Image image;

    private void Awake()
    {




    }

    public void SetButton(WeaponData data)
    {

        if (image.transform.parent != null)
        {
            // WeaponData�� itemIcon�� Image�� sprite�� ����
            image.sprite = data.itemIcon;

            // Image�� ���ĸ� 1�� ����
            Color imageColor = image.color;
            imageColor.a = 1f;
            image.color = imageColor;
        }
        else
        {
            Debug.LogWarning("Image ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

}
