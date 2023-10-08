using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public GameObject player;
    public WeaponData data;
    public int level;

    Image icon;
    Text textlevel;
    Text textdesc2;

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
        Text[] texts = GetComponentsInChildren<Text>();
        foreach (var text in texts)
        {
            if (text.transform.parent != null && text.transform.parent.name == "TextArea")
            {
                textlevel = text;
                textlevel.text = "Lv." + (level);
                break;
            }
        }
        foreach (var text in texts)
        {
            if (text.transform.parent != null && text.transform.parent.name == "DescArea")
            {
                textdesc2 = text;
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
                player.GetComponent<Player>().Heal(data.levels[level]);
                break;
        }


        if(level == data.levels.Length-1)
        {
            GetComponent<Button>().interactable = false;
        }
    }

}
