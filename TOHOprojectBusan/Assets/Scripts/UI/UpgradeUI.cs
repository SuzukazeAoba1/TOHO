using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UpgradeUI : MonoBehaviour
{
    public int maxEquip = 2;
    RectTransform rect;
    UpgradeButton[] Buttons;
    UpgradeButton[] items;
    UpgradeButton[] weapons;
    public UpgradeButton[] selected;

    public Button Healitem;
    private bool isPaused;
    private int selectcount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        Buttons = GetComponentsInChildren<UpgradeButton>(true);
        weapons = Buttons.Where(item => item.gameObject.name.Contains("Weapon")).ToArray();
        items = Buttons.Where(item => item.gameObject.name.Contains("Item")).ToArray();
        selected = new UpgradeButton[maxEquip];


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
        if(Notnullcount() < maxEquip)
        {
            for(int i = 0; i < Buttons.Length; i++)
            {
                if(Buttons[i].GetComponent<UpgradeButton>().data == recievedata)
                {
                    selected[selectcount] = Buttons[i];
                    selectcount++;
                    Notnullcount();
                }
            }
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
        if (Notnullcount() < maxEquip)
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
                ranItem.gameObject.SetActive(true);

            }
        }
        else if (Notnullcount() == maxEquip)
        {
            while (true)
            {
                ran[0] = Random.Range(0, selected.Length);
                ran[1] = Random.Range(0, selected.Length);
                ran[2] = Random.Range(0, selected.Length);
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
        //��Ģ 1. ������ �ȵ�
    }

    private int Notnullcount()
    {
        int nonNullCount = selected.Count(item => item != null);
        return nonNullCount;
    }

    
}
