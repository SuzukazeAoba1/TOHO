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
            if (weaponId == 4)
            {
                level++;
                currentlevel++;
                float[] cooltimes = { 150, 90, 75, 40 };
                GetComponent<MastersparkManager>().cooltimego(cooltimes[level]);
                // 배열을 사용하거나 처리하는 코드 추가
            }
            else
            {
                level++;
                currentlevel++;
                ActivateSelectedLevel(level);
            }

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
