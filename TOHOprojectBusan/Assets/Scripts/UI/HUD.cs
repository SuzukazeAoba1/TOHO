using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Incredivilty, Text}

    public InfoType type;

    TextMeshProUGUI text;
    Slider myslider;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
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
            case InfoType.Incredivilty:
                break;
            case InfoType.Text:
                int minutes = Mathf.FloorToInt(GameManager.instance.gameTime / 60f);
                int remainingSeconds = Mathf.FloorToInt(GameManager.instance.gameTime % 60f);
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
                else if (remainingSeconds % 60 == 0)
                {
                    second = "00";
                    minute = (minute + 1).ToString();
                }
                else
                {
                    second = remainingSeconds.ToString();
                }
                text.text = minute + " : " + second;
                break;

        }
    }
}
