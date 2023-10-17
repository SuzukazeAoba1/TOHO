using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueUI : MonoBehaviour
{
    public int maxEquip = 3;
    RectTransform rect;
    public ItemGUI itemgui;
    ContinueButton[] Buttons;
    AudioSource pausesound;
    public AudioSource background;

    public Button Healitem;
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
        Debug.Log("숨겨짐");
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

            //Debug.Log(selectcount + "번 선택되었습니다");
            selectcount++;
            //Debug.Log(selected[selectcount - 1]); // 수정된 부분
        }
        else if (selectcount >= maxEquip)
        {
            //Debug.Log("무기 다 선택됨");
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

    /*void Next()
    {
        //모든 아이템을 비활성화하고,

        foreach (UpgradeButton item in Buttons)
        {
            item.gameObject.SetActive(false);
        }
        //그 중에서 규칙에 맞는 랜덤 아이템 3개 활성화
        int[] ran = new int[3];
        if (selectcount < maxEquip)
        {
            while (true)
            {
                ran[0] = Random.Range(0, weapons.Length);
                ran[1] = Random.Range(0, weapons.Length);
                ran[2] = Random.Range(0, weapons.Length);
                if (ran[0] != ran[1] && ran[1] != ran[2] && ran[2] != ran[0])
                {
                    break;
                }

            }

            for (int index = 0; index < ran.Length; index++)
            {
                UpgradeButton ranItem = weapons[ran[index]];

                if (ranItem.level == ranItem.data.levels.Length - 1)
                {
                    items[Random.Range(0, items.Length)].gameObject.SetActive(true);
                }
                else
                {
                    ranItem.gameObject.SetActive(true);
                }

            }
        }
        else if (selectcount >= maxEquip)
        {

            while (true)
            {
                ran[0] = Random.Range(0, selectcount);
                ran[1] = Random.Range(0, selectcount);
                ran[2] = Random.Range(0, selectcount);
                if (ran[0] != ran[1] && ran[1] != ran[2] && ran[2] != ran[0])
                {
                    break;
                }

            }

            for (int index = 0; index < ran.Length; index++)
            {
                UpgradeButton ranItem = selected[ran[index]];

                //규칙 1. 만렙은 안됨. 만렙이면 소비아이템으로  대체
                if (ranItem.level == ranItem.data.levels.Length - 1)
                {
                    items[Random.Range(0, items.Length)].gameObject.SetActive(true);
                }
                else
                {
                    ranItem.gameObject.SetActive(true);
                }

            }
        }
        //규칙 1. 만렙은 안됨
    }*/




}
