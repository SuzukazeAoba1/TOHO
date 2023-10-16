using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    public int weaponId = 0;
    public GameObject[] levels;
    public int currentlevel = 1;
    private int level = 0;
    public int Maxlevel = 4;
    public KeyCode keyCode = KeyCode.Q;

    // Start is called before the first frame update
    void Start()
    {
        if(weaponId != 4)
        {
            levels = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                levels[i] = transform.GetChild(i).gameObject;

            }
            ActivateSelectedLevel(level);
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
                case 4:
                    
                    float[] cooltimes = { 150, 90, 75, 40 };
                    GetComponent<MastersparkManager>().set_cooltime = cooltimes[level];
                    GetComponent<MastersparkManager>().StartShoot();
                    break;
                case 5:
                    float[] cooltimes2 = { 30, 20, 12, 7 };
                    float[] healthes = { 1000, 1500, 2000, 2500 };
                    GetComponent<KogasaManager>().time_to_spawn = cooltimes2[level];
                    GetComponent<KogasaManager>().kogasahp = healthes[level];
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
                // �迭�� ����ϰų� ó���ϴ� �ڵ� �߰�
            }
            else
            {
                
            }*/

        }
        else
        {
            Debug.Log("�� ���׷��̵� ����");
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
