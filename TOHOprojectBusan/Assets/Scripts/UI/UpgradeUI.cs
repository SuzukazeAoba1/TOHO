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
        //버튼 중에서 이름에 Weapon이 있는 개체만 선별
        weapons = Buttons.Where(item => item.gameObject.name.Contains("Weapon")).ToArray();
        //버튼 중에서 이름에 item이 있는 개체만 선별
        heals = Buttons.Where(item => item.gameObject.name.Contains("Heal")).ToArray();

        //weapons의 개체를 notmaxweapon에 넣음(상관 없음)
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

    //게임이 시작될때 한번 작동하는 함수(게임 매니저에서 동작함)
    public void Select(int index)
    {
        Buttons[index].Onclik();
        Debug.Log("기본 무기 지급됨");


    }

    public void SetdataofButton(WeaponData recievedata) //새 무기를 골랐을 때 이를 등록하는 함수
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
        else if (selectcount >= maxEquip) //selectcount가 maxEquip 이상일 경우(스크립트가 정상작동 한다면 작동안함)
        {
            Debug.Log("무기 다 선택됨");
        }
    }

    void TogglePause() //일시정지(UI 작동 시 사용)
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
        int ranlength = 3;
        int[] ran = new int[ranlength];
        //아이템이 MaxEquip보다 낮을 경우(착용할 아이템이 남아있을 경우)
        //특정 아이템의 레벨이 max일시 레벨이 max가 아닌 다른 아이템으로 대체
        if (selectcount < maxEquip)
        {
            //
            while (true)
            {
                //notmaxweapon에서 
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
        //아이템창이 꽉 찼을 경우
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
                        Debug.Log("힐 추가됨");
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
            // Weapon을 먼저 찾습니다.
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

                // 중복 검사
                if (!excludeIndices.Contains(newIndex))
                {
                    newButton = availableButtons[newIndex];
                    break;
                }
            }

            return newButton;
        }*/
        //규칙 1. 만렙은 안됨
    }




}
