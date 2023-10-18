using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UpgradeUI : MonoBehaviour
{
    public int maxEquip = 3;
    RectTransform rect;
    public ItemGUI itemgui;
    UpgradeButton[] Buttons;
    UpgradeButton[] items;
    UpgradeButton[] weapons;
    public List<UpgradeButton> notmaxweapon = new List<UpgradeButton>();
    AudioSource pausesound;
    public List<UpgradeButton> selected = new List<UpgradeButton>();

    public Button Healitem;
    private bool isPaused;
    public int selectcount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        pausesound = GetComponent<AudioSource>();
        rect = GetComponent<RectTransform>();
        Buttons = GetComponentsInChildren<UpgradeButton>(true);
        weapons = Buttons.Where(item => item.gameObject.name.Contains("Weapon")).ToArray();
        items = Buttons.Where(item => item.gameObject.name.Contains("Item")).ToArray();

        for (int i = 0; i < weapons.Length; i++)
        {
            notmaxweapon.Add(weapons[i]);
        }


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
        Next();
        pausesound.Play();
        rect.localScale = new Vector3(1, 1, 1);
        TogglePause();
    }

    public void Hide()
    {
        rect.localScale = new Vector3(0, 0, 0);
        TogglePause();
    }

    public void Select(int index)
    {
        Buttons[index].Onclik();
        Debug.Log("�⺻ ���� ���޵�");


    }

    public void SetdataofButton(WeaponData recievedata)
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
    }

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

    void Next()
    {
        //��� �������� ��Ȱ��ȭ�ϰ�,

        foreach (UpgradeButton item in Buttons)
        {
            item.gameObject.SetActive(false);
        }
        //�� �߿��� ��Ģ�� �´� ���� ������ 3�� Ȱ��ȭ
        int[] ran = new int[3];
        if (selectcount < maxEquip)
        {
            while (true)
            {
                ran[0] = Random.Range(0, notmaxweapon.Count);
                ran[1] = Random.Range(0, notmaxweapon.Count);
                ran[2] = Random.Range(0, notmaxweapon.Count);
                if (ran[0] != ran[1] && ran[1] != ran[2] && ran[2] != ran[0])
                {
                    break;
                }

            }

            for (int index = 0; index < ran.Length; index++)
            {
                UpgradeButton ranItem = notmaxweapon[ran[index]];

                if (ranItem.level == ranItem.data.levels.Length - 1)
                {
                    UpgradeButton newButton = FindNewButton(notmaxweapon, ran);

                    // ranItem ��ü
                    notmaxweapon[ran[index]] = newButton;

                    newButton.gameObject.SetActive(true);
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

                //��Ģ 1. ������ �ȵ�. �����̸� �Һ����������  ��ü
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

        UpgradeButton FindNewButton(List<UpgradeButton> availableButtons, int[] excludeIndices)
        {
            UpgradeButton newButton = null;

            while (true)
            {
                int newIndex = Random.Range(0, availableButtons.Count);

                // �ߺ� �˻�
                if (!excludeIndices.Contains(newIndex))
                {
                    newButton = availableButtons[newIndex];
                    break;
                }
            }

            return newButton;
        }
        //��Ģ 1. ������ �ȵ�
    }



    
}
