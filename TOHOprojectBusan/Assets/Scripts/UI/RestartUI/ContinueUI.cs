using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueUI : MonoBehaviour
{
    RectTransform rect;
    ContinueButton[] Buttons;
    AudioSource pausesound;
    public AudioSource background;
    private bool isPaused;
    public int selectcount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        pausesound = GetComponent<AudioSource>();
        rect = GetComponent<RectTransform>();
        Buttons = GetComponentsInChildren<ContinueButton>(true);


    }

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        background.Pause();
        pausesound.Play();
        pausesound.Play();
        rect.localScale = new Vector3(1, 1, 1);
        TogglePause();
    }

    public void Hide()
    {
        background.Play();
        Debug.Log("������");
        rect.localScale = new Vector3(0, 0, 0);
        TogglePause();
    }

    public void Select(int index)
    {
        Buttons[index].Onclick();

    }

    /*public void SetdataofButton(WeaponData recievedata)
    {
        if (selectcount < maxEquip)
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                if (Buttons[i].GetComponent<UpgradeButton>().data == recievedata)
                {
                    selected.Add(Buttons[i]);
                    itemgui.GetitemSlot(selectcount, recievedata);
                }
            }

            //Debug.Log(selectcount + "�� ���õǾ����ϴ�");
            selectcount++;
            //Debug.Log(selected[selectcount - 1]); // ������ �κ�
        }
        else if (selectcount >= maxEquip)
        {
            //Debug.Log("���� �� ���õ�");
        }
    }*/

    public void ADDweapon(UpgradeButton button)
    {

    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
