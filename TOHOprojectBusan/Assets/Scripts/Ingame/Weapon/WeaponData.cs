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

    [Header("# 무기에 따라 사용하는 구간")]

    public float[] ATK;
    public float[] cooltimes;
    public float[] healthes;
    public int[] counts;

    [Header("# Weapon")]
    public GameObject Weaponobject;
}
