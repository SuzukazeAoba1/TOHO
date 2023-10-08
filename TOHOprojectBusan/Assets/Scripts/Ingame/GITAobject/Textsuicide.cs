using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textsuicide : MonoBehaviour
{

    public float destroy_Time = 0.7f;
    public float moveSpeed = 1.2f;
    private void OnEnable()
    {
        Invoke("DeactivateSelf", destroy_Time);
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, moveSpeed, Time.fixedDeltaTime));
    }
}