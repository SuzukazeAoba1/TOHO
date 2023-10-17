using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoriyaManager : MonoBehaviour
{
    public GameObject soul;
    public Transform player;
    public GameObject parent;
    public MoriyaHit[] souls;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        parent = GameObject.Find("Moriyas");
    }

    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Spawn(2);
        }
    }

    public void Spawn(int count)
    {
        for(int i = 0; i < count; i++)
        {

            GameObject newSoul = Instantiate(soul, parent.transform);
            newSoul.transform.position = player.position;

        }
    }

    public void UpgradeHP(float newhealth)
    {
        souls = parent.GetComponentsInChildren<MoriyaHit>();
        for(int i = 0; i<souls.Length; i++)
        {
            souls[i].max_health = newhealth;
            souls[i].health = newhealth;
        }
    }
}
