using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGUI : MonoBehaviour
{
    public Transform healthesParent;
    public Image Health;
    private List<Image> healthImages = new List<Image>();

    // Start is called before the first frame update
    public void HealthSet(int currenthealth)
    {

        for (int i = 0; i < currenthealth; i++)
        {
            HealthPush(1);
        }
    }
    public void HealthPush(int count)
    {
        Image newHealth = Instantiate(Health, healthesParent);
        healthImages.Add(newHealth);
    }

    public void HealhtPull()
    {
        if (healthImages.Count > 0)
        {
            // 체력이 감소할 때마다 가장 마지막의 Health 이미지를 비활성화
            int lastIndex = healthImages.Count - 1;
            healthImages[lastIndex].gameObject.SetActive(false);
            healthImages.RemoveAt(lastIndex);
        }
    }

}
