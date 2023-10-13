using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public GameObject player;
    public WeaponData data;
    public int level;
    public UpgradeUI upgradeUI;

    Image icon;
    TextMeshProUGUI textlevel;
    TextMeshProUGUI textex;
    TextMeshProUGUI textdesc;
    TextMeshProUGUI textname;

    private void Awake()
    {
        Image[] images = GetComponentsInChildren<Image>();

        foreach (var image in images)
        {
            if (image.transform.parent != null && image.transform.parent.name == "IconArea")
            {
                icon = image;
                icon.sprite = data.itemIcon;
                break;
            }
        }


        


    }

    private void OnEnable()
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in texts)
        {
            if (text.transform.parent != null && text.transform.parent.name == "NameArea")
            {
                textname = text;
                textname.text = data.itemName;
                break;
            }
        }
        foreach (var text in texts)
        {
            if (text.transform.parent != null && text.transform.parent.name == "LevelArea")
            {
                textlevel = text;
                if (level == 0)
                {
                    textlevel.text = "»õ ¹«±â";
                }
                else if (level < data.levels.Length - 2)
                {
                    textlevel.text = "Lv." + (level) + " ¡æ " + (level + 1);
                }
                else if (level >= data.levels.Length - 2)
                {
                    textlevel.text = "Lv." + (level) + " ¡æ Lv.MAX";
                }
                
                //textlevel.text = "Lv." + (level);
                break;
            }
        }
        foreach (var text in texts)
        {
            if (text.transform.parent != null && text.transform.parent.name == "DescArea")
            {
                textdesc = text;
                textdesc.text = data.itemDesc[level];
                break;
            }
        }
        foreach (var text in texts)
        {
            if (text.transform.parent != null && text.transform.parent.name == "ExArea")
            {
                textex = text;
                textex.text = data.itemEx[level];
                break;
            }
        }
    }
    private void LateUpdate()
    {

    }

    public void Onclik()
    {
        switch (data.itemType)
        {
            case WeaponData.ItemType.Weapon:
                if (level == 0)
                {
                    GameObject newWeapon = Instantiate(data.Weaponobject, player.transform);
                    upgradeUI.SetdataofButton(data);
                }
                else
                {
                    WeaponUpgrade[] upgrades = player.GetComponentsInChildren<WeaponUpgrade>();
                    foreach (var upgrade in upgrades)
                    {
                        if (upgrade.weaponId == data.weaponID)
                        {
                            upgrade.Levelup();
                        }
                    }
                }

                level++;
                break;
            case WeaponData.ItemType.Heal:
                if (player.GetComponent<Player>().health < player.GetComponent<Player>().maxHealth)
                {
                    player.GetComponent<Player>().Heal(data.levels[level]);
                }
                break;
        }

        if (level == data.levels.Length - 1)
        {
            GetComponent<Button>().interactable = false;
        }
    }
    /*public void Onclik()
    {
        switch (data.itemType)
        {
            case WeaponData.ItemType.Weapon:
                if (level == 0)
                {
                    GameObject newWeapon = Instantiate(data.Weaponobject, player.transform);
                    upgradeUI.SetdataofButton(data);
                }
                else
                {
                    WeaponUpgrade[] upgrades = player.GetComponentsInChildren<WeaponUpgrade>();
                    foreach (var upgrade in upgrades)
                    {
                        if (upgrade.weaponId == data.weaponID)
                        {
                            upgrade.ActivateSelectedLevel(level);
                        }
                    }
                }

                
                level++;
                break;
            case WeaponData.ItemType.Heal:
                if(player.GetComponent<Player>().health < player.GetComponent<Player>().maxHealth)
                {
                    player.GetComponent<Player>().Heal(data.levels[level]);
                }
                break;
        }


        if(level == data.levels.Length-1)
        {
            GetComponent<Button>().interactable = false;
        }
    }
    */

}
