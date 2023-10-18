using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    public int weaponId;
    public GameObject[] levels;
    public WeaponData weapon;
    public int currentlevel = 1;
    private int level = 0;
    public int Maxlevel = 4;
    public KeyCode keyCode = KeyCode.Q;

    // Start is called before the first frame update
    void Start()
    {
        weaponId = weapon.weaponID;
        switch(weaponId)
        {
            case 4:
                break;
            case 5:
                break;
            case 7:
                GetComponent<MoriyaManager>().Spawn(1);
                break;
            default:
                levels = new GameObject[transform.childCount];
                for (int i = 0; i < transform.childCount; i++)
                {
                    levels[i] = transform.GetChild(i).gameObject;

                }
                ActivateSelectedLevel(level);
                break;
        }
        
    }

    public void Levelup()
    {
        if (level < Maxlevel - 1)
        {
            level++;
            currentlevel++;
            switch (weaponId)
            {
                case 1:
                    GetComponent<CircleMove>().speed = weapon.cooltimes[level];
                    ActivateSelectedLevel(level);
                    break;
                case 4:
                    
                    //float[] cooltimes = { 150, 90, 75, 50 };
                    GetComponent<MastersparkManager>().set_cooltime = weapon.cooltimes[level];
                    GetComponent<MastersparkManager>().StartShoot();
                    break;
                case 5:
                    //float[] cooltimes2 = { 30, 20, 12, 7 };
                    //float[] khealthes = { 1000, 1500, 2000, 2500 };
                    GetComponent<KogasaManager>().time_to_spawn = weapon.cooltimes[level];
                    GetComponent<KogasaManager>().kogasahp = weapon.healthes[level];
                    break;

                case 7:
                    //int[] spawns = { 0, 1, 2, 3, 4 };
                    //float[] mhealthes = { 250, 250, 500, 750, 1000 };
                    GetComponent<MoriyaManager>().Spawn(weapon.counts[level]);
                    GetComponent<MoriyaManager>().UpgradeHP(weapon.healthes[level]);
                    break;
                default:
                    ActivateSelectedLevel(level);
                    break;
            }
            /*if (weaponId == 4)
            {
                level++;
                currentlevel++;
                float[] cooltimes = { 150, 90, 75, 40 };
                GetComponent<MastersparkManager>().set_cooltime = cooltimes[level];
                GetComponent<MastersparkManager>().StartShoot();
                // 배열을 사용하거나 처리하는 코드 추가
            }
            else
            {
                
            }*/

        }
        else
        {
            Debug.Log("더 업그레이드 못행");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

            
    }

    private void DeactivateChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ActivateSelectedLevel(int level)
    {
        for (int i = 0; i <levels.Length; i++)
        {
            levels[i].SetActive(i == level);
        }
    }
}
