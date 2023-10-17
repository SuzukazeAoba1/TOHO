using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KogasaManager : MonoBehaviour
{
    public GameObject kogasa;
    public TextMeshPro timeUI;
    public float time_to_spawn = 15.5f;
    public float kogasahp = 1000f;
    private float cooltime = 15.5f;
    public Transform player;
    public GameObject spawnpoint;
    public KogasaHit current_kogasa;
    private bool summoned;

    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<Player>().transform;
        spawnpoint = GameObject.Find("KogasaSpawnPoint");
        summoned = false;
    }

    private void Start()
    {
        InvokeRepeating("KogasaCheck", 0f, 0.3f);
    }

    private void OnEnable()
    {
        cooltime = time_to_spawn;
        current_kogasa = spawnpoint.GetComponentInChildren<KogasaHit>();

        if(!current_kogasa)
        {
            Debug.Log("현재 코가사 없음");
            summoned = false;
        }
        else if(current_kogasa)
        {
            Debug.Log("현재 코가사 있음!");
            summoned = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (current_kogasa)
        {
            timeUI.text = "Summoned!";
        }
        else if(!current_kogasa)
        {
            if(summoned)
            {
                summoned = false;
                cooltime = time_to_spawn;
            }
            else if(!summoned)
            {
                cooltime -= Time.deltaTime;
                if (cooltime <= 0)
                {
                    summoned = true;
                    KogasaSummon();
                }
                timeUI.text = cooltime.ToString("F" + 2);
            }
            
        }
    }

    public void KogasaSummon()
    {
        summoned = true;
        spawnpoint.transform.position = player.position;
        GameObject newKogasa = Instantiate(kogasa, spawnpoint.transform);
        newKogasa.GetComponent<KogasaHit>().hp = kogasahp;
        newKogasa.transform.position = spawnpoint.transform.position;
        timeUI.text = "Summoned!";

    }

    public void KogasaCheck()
    {
        current_kogasa = spawnpoint.GetComponentInChildren<KogasaHit>();
    }
}
