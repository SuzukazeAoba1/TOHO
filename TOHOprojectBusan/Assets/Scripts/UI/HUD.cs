using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Text}

    public InfoType type;

    Text text;
    Slider myslider;

    private void Awake()
    {
        text = GetComponent<Text>();
        myslider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level , GameManager.instance.nextExp.Length - 1)];
                myslider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                float level = GameManager.instance.level;
                text.text = "LV." + level;
                break;
            case InfoType.Kill:
                break;
            case InfoType.Text:
                float minutes = Mathf.FloorToInt(GameManager.instance.gameTime / 60f);
                float remainingSeconds = Mathf.RoundToInt(GameManager.instance.gameTime % 60f);
                string minute;
                string second;
                if(minutes < 10)
                {
                    minute = "0" + minutes.ToString();
                }
                else
                {
                    minute = minutes.ToString();
                }
                if (remainingSeconds < 10)
                {
                    second = "0" + remainingSeconds.ToString();
                }
                else
                {
                    second = remainingSeconds.ToString();
                }
                text.text = "버틴 시간 : " + minute + " : " + second;
                break;

        }
    }
}
