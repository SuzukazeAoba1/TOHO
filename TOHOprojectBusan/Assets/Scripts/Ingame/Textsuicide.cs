using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textsuicide : MonoBehaviour
{

    public float destroy_Time = 0.7f;
    private void OnEnable()
    {
        Invoke("DeactivateSelf", destroy_Time);
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}