using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public int prefabId;
    public int count;
    public float speed;
    public GameObject Player;
    public GameObject[] Weapons;
    private List<int> canSummon = new List<int>();

    private void Awake()
    {
        canSummon.Clear(); // 리스트 초기화

        for (int i = 0; i < Weapons.Length; i++)
        {
            canSummon.Add(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Summon(2);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Summon(1);
        }
    }

    public void Summon(int id)
    {
        if (canSummon.Contains(id))
        {
            GameObject newweapon = Instantiate(Weapons[id], Player.transform);
            canSummon.Remove(id);
        }
        else
        {
            Debug.Log("무기가 없엉");
        }
    }
}
