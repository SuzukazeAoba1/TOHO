using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UpgradeUI : MonoBehaviour
{
    public int MaxEquip = 4;
    RectTransform rect;
    UpgradeButton[] Buttons;
    UpgradeButton[] items;
    UpgradeButton[] weapons;
    public UpgradeButton[] selected;

    public Button Healitem;
    private bool isPaused;

    // Start is called before the first frame update
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        Buttons = GetComponentsInChildren<UpgradeButton>(true);
        weapons = Buttons.Where(item => item.gameObject.name.Contains("Weapon")).ToArray();
        items = Buttons.Where(item => item.gameObject.name.Contains("Item")).ToArray();
        selected = new UpgradeButton[MaxEquip];


    }

    private void Start()
    {
        Debug.Log(selected[0]);
        Notnullcount();
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
        //if(selected.)
        Buttons[index].Onclik();
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
        //모든 아이템을 비활성화하고,

        foreach (UpgradeButton item in Buttons)
        {
            item.gameObject.SetActive(false);
        }
        //그 중에서 규칙에 맞는 랜덤 아이템 3개 활성화
        int[] ran = new int[3];
        while (true)
        {
            ran[0] = Random.Range(0, weapons.Length);
            ran[1] = Random.Range(0, weapons.Length);
            ran[2] = Random.Range(0, weapons.Length);
            if (ran[0]!=ran[1] && ran[1]!=ran[2]&& ran[2] != ran[0])
            {
                break;
            }
                
        }

        for (int index=0; index < ran.Length; index++)
        {
            UpgradeButton ranItem = weapons[ran[index]];

            //규칙 1. 만렙은 안됨. 만렙이면 소비아이템으로  대체
            if (ranItem.level == ranItem.data.levels.Length-1)
            {
                items[Random.Range(0, items.Length)].gameObject.SetActive(true);
            }
            else
            {
                ranItem.gameObject.SetActive(true);
            }
            
        }
        //규칙 1. 만렙은 안됨
    }

    private int Notnullcount()
    {
        int nonNullCount = selected.Count(item => item != null);
        Debug.Log(nonNullCount);
        return nonNullCount;
    }
}
