using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptble Object")]
public class WeaponData : ScriptableObject
{

    public enum ItemType { Weapon, Heal}
    [Header("# Main infomation")]

    public ItemType itemType;
    public int weaponID;
    public string itemName;

    [TextArea]
    public string[] itemDesc;
    [TextArea]
    public string[] itemEx;
    public Sprite itemIcon;

    [Header("# Level Data")]

    public int[] levels;

    [Header("# Weapon")]
    public GameObject Weaponobject;
}
