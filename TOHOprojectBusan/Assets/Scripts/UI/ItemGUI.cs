using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemGUI : MonoBehaviour
{
    private Image[] childs;
    public Image[] slots;

    private void Awake()
    {
        childs = GetComponentsInChildren<Image>();
        slots = childs.Where(item => item.gameObject.name.Contains("ItemSlot")).ToArray();
    }

    private void Start()
    {
        /*Debug.Log(slots[0]);
        Debug.Log(slots[1]);
        Debug.Log(slots[2]);
        Debug.Log(slots[3]);
        Debug.Log(slots[4]);*/
    }
    public void GetitemSlot(int i, WeaponData data)
    {
        // i 값이 slots 배열의 범위 안에 있는지 확인
        if (i >= 0 && i < slots.Length)
        {
            // slots[i]가 null이 아닌지 확인
            if (slots[i] != null)
            {
                // GetComponent<ItemSlotGui>()의 결과가 null이 아닌지 확인
                ItemSlotGui itemSlotGui = slots[i].GetComponent<ItemSlotGui>();
                if (itemSlotGui != null)
                {
                    // 모든 검사를 통과하면 SetButton 호출
                    itemSlotGui.SetButton(data);
                }
                else
                {
                    Debug.LogError("ItemSlotGui component not found on: " + slots[i].name);
                }
            }
            else
            {
                Debug.LogError("Slot at index " + i + " is null.");
            }
        }
        else
        {
            // 범위를 벗어나면 에러 로그 출력 또는 예외 처리 등을 수행
            Debug.LogError("Invalid index: " + i);
        }
    }

}
