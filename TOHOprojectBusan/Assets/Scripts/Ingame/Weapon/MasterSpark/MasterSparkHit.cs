using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSparkHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Color eC = other.GetComponent<SpriteRenderer>().color;

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Barrage"))
        {


            other.gameObject.SetActive(false);

        }


    }
}