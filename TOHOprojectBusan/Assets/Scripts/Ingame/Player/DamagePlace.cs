using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlace : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Barrage"))
        {
            player.GetComponent<Player>().Damage();
        }
            
    }


}
