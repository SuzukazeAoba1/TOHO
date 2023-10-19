using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvincibilityUI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gManager;
    public float time;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            text.text = " ";
        }
        else if (time >= 700)
        {
            gManager.cflag = true;
            text.text = "치트 모드";
        }
        else
        {
            text.text = "무적시간" + time.ToString("F" + 2);
        }
    }
}
