using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePatten : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Moving());
    }


    IEnumerator Moving()
    {
        GetComponent<Transform>().Translate(Vector3.down * 100 * Time.deltaTime);
        yield return new WaitForSeconds(.5f);
        GetComponent<Transform>().Translate(Vector3.up * 100 * Time.deltaTime);
    }
}
