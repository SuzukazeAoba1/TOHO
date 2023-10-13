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
        // i ���� slots �迭�� ���� �ȿ� �ִ��� Ȯ��
        if (i >= 0 && i < slots.Length)
        {
            // slots[i]�� null�� �ƴ��� Ȯ��
            if (slots[i] != null)
            {
                // GetComponent<ItemSlotGui>()�� ����� null�� �ƴ��� Ȯ��
                ItemSlotGui itemSlotGui = slots[i].GetComponent<ItemSlotGui>();
                if (itemSlotGui != null)
                {
                    // ��� �˻縦 ����ϸ� SetButton ȣ��
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
            // ������ ����� ���� �α� ��� �Ǵ� ���� ó�� ���� ����
            Debug.LogError("Invalid index: " + i);
        }
    }

}
