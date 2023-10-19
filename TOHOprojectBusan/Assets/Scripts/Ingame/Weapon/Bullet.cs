using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
    
    public float ATK;
    public int effectID = 1;
    private int eID = 0;
    public float attackpoint = 5;
    public float Speed;
    public float destroy_Time = 4;
    private float time_To_Destroy;
    public GameObject DText;
    private AudioSource myAS;
    private GameObject damageText;
    private GameObject effect;
    public float offset = 0.7f;

    private void Awake()
    {
        myAS = GetComponent<AudioSource>();
        eID = effectID - 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        Player playerscript = FindObjectOfType<Player>();

        attackpoint = ATK;
        time_To_Destroy= destroy_Time;
        //TextMesh Damage_text = DText.GetComponent<TextMesh>();
    }



    void OnEnable()
    {
        attackpoint = ATK;
        StartCoroutine(DeactivateAfterTime((float)time_To_Destroy));
    }

    // time_To_Destroy 이후에 게임 오브젝트를 비활성화하는 코루틴
    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (attackpoint <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DestroyDamageAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        damageText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Color eC = other.GetComponent<SpriteRenderer>().color;
        
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            //myAS.Play();
            Color othercolor = other.gameObject.GetComponent<SpriteRenderer>().color;
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(othercolor.r / 3, othercolor.g / 3, othercolor.b / 3);
            other.gameObject.GetComponent<Enemy>().isdamaged = true;
            Vector3 ePosition = other.ClosestPoint(transform.position);
            ePosition.y += offset;
            effect = GameManager.instance.EffectPool.Get(eID);
            effect.transform.position = other.ClosestPoint(transform.position);
            damageText = GameManager.instance.GitaPool.Get(0);
            damageText.transform.position = ePosition;
            other.gameObject.GetComponent<Enemy>().Damage(attackpoint);
            //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 4f, other.transform.localScale.y / 4f, other.transform.localScale.z / 4f);
            damageText.GetComponent<TextMeshPro>().text = attackpoint.ToString();
            gameObject.SetActive(false);

        }
        else if (other.gameObject.CompareTag("Barrage"))
        {
            //myAS.Play();
            effect = GameManager.instance.EffectPool.Get(eID);
            Vector3 ePosition = other.ClosestPoint(transform.position);
            ePosition.y += offset;

            if (attackpoint > other.gameObject.GetComponent<Barrage>().HP)
            {
                ePosition.y += offset;
                effect.transform.position = other.ClosestPoint(transform.position);
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = ePosition;
                //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 6f, other.transform.localScale.y / 6f, other.transform.localScale.z / 6f);
                damageText.GetComponent<TextMeshPro>().text = attackpoint.ToString();
                other.gameObject.GetComponent<Barrage>().Kill();
                attackpoint = attackpoint - other.gameObject.GetComponent<Barrage>().HP;
            }
            else if(attackpoint <= other.gameObject.GetComponent<Barrage>().HP)
            {
                ePosition.y += offset;
                effect.transform.position = other.ClosestPoint(transform.position);
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = ePosition;
                //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 6f, other.transform.localScale.y / 6f, other.transform.localScale.z / 6f);
                damageText.GetComponent<TextMeshPro>().text = attackpoint.ToString();
                other.gameObject.GetComponent<Barrage>().Damage(attackpoint);
                gameObject.SetActive(false);
            }
            
            
        }


    }
    
    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
    private void DestroyDamage()
    {
        damageText.SetActive(false);
    }


}
