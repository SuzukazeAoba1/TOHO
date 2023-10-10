using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float effectTime = 0.32f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Invoke("Deactive", effectTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
