using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoriyaHit : MonoBehaviour
{
    [Header("# 스테이터스")]
    public float max_health;
    public float health = 500;
    public int effectID = 6;
    private int eID = 5;

    public float Cooltime;

    public float destroy_Time;
    private GameObject damageText;
    private GameObject effect;
    public float offset = 0.7f;

    public MoriyaMove myMM;

    // Start is called before the first frame update

    private void Awake()
    {
        myMM = GetComponent<MoriyaMove>();
    }
    void Start()
    {
        eID = effectID - 1;
        health = max_health;
        Player playerscript = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            myMM.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Barrage"))
        {
            if(myMM.isAlive)
            {
                Vector3 ePosition = other.ClosestPoint(transform.position);
                ePosition.y += offset;

                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = other.ClosestPoint(transform.position);

                effect = GameManager.instance.EffectPool.Get(eID);
                effect.transform.position = other.ClosestPoint(transform.position);

                health -= other.gameObject.GetComponent<Barrage>().HP;
                damageText.GetComponent<TextMeshPro>().text = other.gameObject.GetComponent<Barrage>().HP.ToString();
                other.gameObject.GetComponent<Barrage>().Kill();
                //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 6f, other.transform.localScale.y / 6f, other.transform.localScale.z / 6f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!myMM.isAlive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                myMM.Resurection();
                health = max_health;
            }

        }
    }

    private void OnDestroy()
    {
    }
}
