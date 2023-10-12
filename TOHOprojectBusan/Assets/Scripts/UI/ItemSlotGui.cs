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
            // WeaponData의 itemIcon을 Image의 sprite로 설정
            image.sprite = data.itemIcon;

            // Image의 알파를 1로 설정
            Color imageColor = image.color;
            imageColor.a = 1f;
            image.color = imageColor;
        }
        else
        {
            Debug.LogWarning("Image 컴포넌트를 찾을 수 없습니다.");
        }
    }

}
