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
    UpgradeButton[] heals;
    UpgradeButton[] weapons;
    public List<UpgradeButton> notmaxweapon = new List<UpgradeButton>();
    public List<UpgradeButton> selected = new List<UpgradeButton>();
    AudioSource pausesound;
    

    public Button Healitem;
    private bool isPaused;
    public int selectcount = 0;
    public int healcount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        pausesound = GetComponent<AudioSource>();
        rect = GetComponent<RectTransform>();
        Buttons = GetComponentsInChildren<UpgradeButton>(true);
        //��ư �߿��� �̸��� Weapon�� �ִ� ��ü�� ����
        weapons = Buttons.Where(item => item.gameObject.name.Contains("Weapon")).ToArray();
        //��ư �߿��� �̸��� item�� �ִ� ��ü�� ����
        heals = Buttons.Where(item => item.gameObject.name.Contains("Heal")).ToArray();

        //weapons�� ��ü�� notmaxweapon�� ����(��� ����)
        for (int i = 0; i < weapons.Length; i++)
        {
            notmaxweapon.Add(weapons[i]);
        }


    }

    private void Start()
    {

    }
    

    // Update is called once per frame

    public void Show()
    {
        Next();
        pausesound.Play();
        GameManager.instance.PuaseManger.InPause(true);
        rect.localScale = new Vector3(1, 1, 1);
    }

    public void Hide()
    {
        rect.localScale = new Vector3(0, 0, 0);
        GameManager.instance.PuaseManger.OutPause(true);
    }

    //������ ���۵ɶ� �ѹ� �۵��ϴ� �Լ�(���� �Ŵ������� ������)
    public void Select(int index)
    {
        Buttons[index].Onclik();
        Debug.Log("�⺻ ���� ���޵�");


    }

    public void SetdataofButton(WeaponData recievedata) //�� ���⸦ ����� �� �̸� ����ϴ� �Լ�
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

            selectcount++;
        }
        else if (selectcount >= maxEquip) //selectcount�� maxEquip �̻��� ���(��ũ��Ʈ�� �����۵� �Ѵٸ� �۵�����)
        {
            Debug.Log("���� �� ���õ�");
        }
    }

    void TogglePause() //�Ͻ�����(UI �۵� �� ���)
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
        int ranlength = 3;
        int[] ran = new int[ranlength];
        //�������� MaxEquip���� ���� ���(������ �������� �������� ���)
        //Ư�� �������� ������ max�Ͻ� ������ max�� �ƴ� �ٸ� ���������� ��ü
        if (selectcount < maxEquip)
        {
            //
            while (true)
            {
                //notmaxweapon���� 
                ran[0] = Random.Range(0, notmaxweapon.Count);
                ran[1] = Random.Range(0, notmaxweapon.Count);
                ran[2] = Random.Range(0, notmaxweapon.Count);
                if (ran[0] != ran[1] && ran[1] != ran[2] && ran[2] != ran[0])
                {
                    break;
                }

            }

            for (int index = 0; index < ranlength; index++)
            {
                UpgradeButton ranItem = notmaxweapon[ran[index]];

                if (ranItem.level == ranItem.data.levels.Length - 1)
                {
                    notmaxweapon.Remove(ranItem);
                    UpgradeButton newButton = FindNewButton(notmaxweapon, ran);

                    if (newButton != null)
                    {
                        newButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.LogError("No eligible button found.");
                    }
                }
                else
                {
                    ranItem.gameObject.SetActive(true);
                }

            }
        }
        //������â�� �� á�� ���
        else if (selectcount >= maxEquip)
        {
            while (true)
            {
                ran[0] = Random.Range(0, selected.Count-1);
                ran[1] = Random.Range(0, selected.Count-1);
                ran[2] = Random.Range(0, selected.Count-1);
                if (ran[0] != ran[1] && ran[1] != ran[2] && ran[2] != ran[0])
                {
                    break;
                }
            }

            for (int index = 0; index < ranlength; index++)
            {
                UpgradeButton ranItem = selected[ran[index]];

                if (ranItem.level == ranItem.data.levels.Length - 1)
                {
                    
                    selected.Remove(ranItem);
                    if (selected.Count <= ranlength)
                    {
                        selected.Add(heals[healcount]);
                        healcount++;
                        Debug.Log("�� �߰���");
                    }


                    UpgradeButton newButton = FindNewButton(selected, ran);

                    if (newButton != null)
                    {
                        newButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.LogError("No eligible button found.");
                    }
                }
                else
                {
                    ranItem.gameObject.SetActive(true);
                    /*if (ranItem.data.itemType == WeaponData.ItemType.Heal)
                    {
                        UpgradeButton newButton = FindNewButton(selected, ran);
                        if (newButton != null)
                        {
                            newButton.gameObject.SetActive(true);
                        }
                        else
                        {
                            Debug.LogError("No eligible button found.");
                        }
                    }
                    else if(ranItem.data.itemType == WeaponData.ItemType.Weapon)
                    {
                        ranItem.gameObject.SetActive(true);
                    }*/

                }
            }
        }
        UpgradeButton FindNewButton(List<UpgradeButton> candidates, int[] exclusion)
        {
            // Weapon�� ���� ã���ϴ�.
            List<UpgradeButton> weaponCandidates = candidates.Where(b => b.gameObject.name.Contains("Weapon") && !exclusion.Contains(candidates.IndexOf(b))).ToList();
            List<UpgradeButton> healCandidates = candidates.Where(b => b.gameObject.name.Contains("Heal") && !exclusion.Contains(candidates.IndexOf(b))).ToList();

            if (weaponCandidates.Count > 0)
            {
                int randomIndex = Random.Range(0, weaponCandidates.Count);
                return weaponCandidates[randomIndex];
            }
            else if (healCandidates.Count > 0)
            {
                int randomIndex = Random.Range(0, healCandidates.Count);
                return healCandidates[randomIndex];
            }
            else
            {
                Debug.LogError("No eligible button found.");
                return null;
            }
        }
        /*UpgradeButton FindNewButton(List<UpgradeButton> availableButtons, int[] excludeIndices)
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
        }*/
        //��Ģ 1. ������ �ȵ�
    }




}
