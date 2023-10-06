using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{

    public GameObject[] levels;
    public int currentlevel = 0;
    public int Maxlevel = 4;
    public KeyCode keyCode = KeyCode.Q;
    // Start is called before the first frame update
    void Start()
    {
        levels = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            levels[i] = transform.GetChild(i).gameObject;
        }
        ActivateSelectedLevel(currentlevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (currentlevel < Maxlevel-1)
            {
                currentlevel++;
                ActivateSelectedLevel(currentlevel);
            }
            else
            {
                Debug.Log("더 업그레이드 못행");
            }
        }
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

    void ActivateSelectedLevel(int level)
    {
        for (int i = 0; i <levels.Length; i++)
        {
            levels[i].SetActive(i == level);
        }
    }
}
