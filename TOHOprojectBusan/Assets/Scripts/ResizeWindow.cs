using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeWindow : MonoBehaviour
{
    public float targetAspectRatio = 5f / 6f;
    private int newWidth;  // newWidth�� ��� ������ ����

    void Start()
    {
        SetResolution();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetResolution();
        }
    }

    void SetResolution()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;

        if (currentAspectRatio > targetAspectRatio)
        {
            int newHeight = Mathf.RoundToInt(Screen.width / targetAspectRatio);
            newWidth = Screen.width;  // newWidth�� ���⼭ ����
            Screen.SetResolution(Screen.width, newHeight, true);
        }
        else
        {
            newWidth = Mathf.RoundToInt(Screen.height * targetAspectRatio);  // newWidth�� ���⼭ ����
            Screen.SetResolution(newWidth, Screen.height, true);
        }

        CenterWindow();
    }

    void CenterWindow()
    {
        // ȭ�� �߾����� �̵�
        int x = (Screen.currentResolution.width - newWidth) / 2;
        int y = (Screen.currentResolution.height - Screen.height) / 2;
        Screen.SetResolution(newWidth, Screen.height, FullScreenMode.Windowed);
    }
}
