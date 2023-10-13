using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GumgiEffect : MonoBehaviour
{
    public float atk = 15f;
    public int effectID = 5;
    private int eID = 4;
    private float attackpoint = 15f;
    private PolygonCollider2D myCL;
    public float effect_time = 0.2f;
    public float ready_time = 0.09f;
    private Animator myAnim;
    private GameObject damageText;
    private GameObject effect;
    public float offset = 0.7f;
    // Start is called before the first frame update

    private void Awake()
    {
        myCL = GetComponent<PolygonCollider2D>();
        myAnim = GetComponent<Animator>();
        attackpoint = atk;
        eID = effectID - 1;
    }
    
    private void OnEnable()
    {
        Invoke("DeactivateSelf", effect_time);
        myCL.enabled = false;
        myAnim.SetBool("Slashing", true);
        Invoke("ColliderOn", ready_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Color eC = other.GetComponent<SpriteRenderer>().color;
        if (other.gameObject.CompareTag("Enemy"))
        {
            Color othercolor = other.gameObject.GetComponent<SpriteRenderer>().color;
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(othercolor.r / 3, othercolor.g / 3, othercolor.b / 3);
            other.gameObject.GetComponent<Enemy>().isdamaged = true;
            effect = GameManager.instance.EffectPool.Get(eID);
            Vector3 ePosition = other.ClosestPoint(transform.position);
            ePosition.y += offset;
            effect.transform.position = other.ClosestPoint(transform.position);
            other.gameObject.GetComponent<Enemy>().Damage(attackpoint);
            damageText = GameManager.instance.GitaPool.Get(0);
            damageText.transform.position = other.ClosestPoint(transform.position);
            //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 4f, other.transform.localScale.y / 4f, other.transform.localScale.z / 4f);
            damageText.GetComponent<TextMeshPro>().text = attackpoint.ToString();
        }
        else if (other.gameObject.CompareTag("Barrage"))
        {
            effect = GameManager.instance.EffectPool.Get(eID);
            Vector3 ePosition = other.ClosestPoint(transform.position);
            ePosition.y += offset;
            effect.transform.position = other.ClosestPoint(transform.position);
            other.gameObject.GetComponent<Barrage>().Damage(attackpoint);
            damageText = GameManager.instance.GitaPool.Get(0);
            damageText.transform.position = ePosition;
            //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 6f, other.transform.localScale.y / 6f, other.transform.localScale.z / 6f);
            damageText.GetComponent<TextMeshPro>().text = attackpoint.ToString();

        }
        void Crestore()
        {
            other.GetComponent<SpriteRenderer>().color = eC;
        }
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
        myAnim.SetBool("Slashing", false);
    }

    private void ColliderOn()
    {
        myCL.enabled = true;
    }
}
