using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    
    public float ATK;
    private float attackpoint = 5;
    public float Speed;
    public float destroy_Time = 4;
    private float time_To_Destroy;
    public GameObject DText;
    private float bulletspeed;
    private GameObject damageText;
    private Vector3 offset = new Vector3(0, 2f, 0);

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        Player playerscript = FindObjectOfType<Player>();

        if (playerscript != null)
        {
            bulletspeed = playerscript.bulletspeed;
        }
        else
        {
            bulletspeed = 0f;
        }
        //Destroy(gameObject, destroy_Time);

        attackpoint = ATK;
        time_To_Destroy= destroy_Time;
        TextMesh Damage_text = DText.GetComponent<TextMesh>();
    }



    void OnEnable()
    {

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            other.gameObject.GetComponent<Enemy>().HP -= attackpoint;
            damageText = GameManager.instance.GitaPool.Get(0);
            damageText.transform.position = transform.position + offset;
            damageText.transform.localScale = new Vector3(other.transform.localScale.x / 5, other.transform.localScale.x / 5, other.transform.localScale.x / 5);
            damageText.GetComponent<TextMesh>().text = attackpoint.ToString();
            gameObject.SetActive(false);

        }
        else if (other.gameObject.CompareTag("Barrage"))
        {
            if (attackpoint > other.gameObject.GetComponent<Barrage>().HP)
            {
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = transform.position + offset;
                damageText.transform.localScale = new Vector3(other.transform.localScale.x / 5, other.transform.localScale.x / 5, other.transform.localScale.x / 5);
                damageText.GetComponent<TextMesh>().text = attackpoint.ToString();
                attackpoint -= other.gameObject.GetComponent<Barrage>().HP;
                Destroy(other.gameObject);
                gameObject.SetActive(false);

            }
            else
            {
                other.gameObject.GetComponent<Barrage>().HP -= attackpoint;
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = transform.position + offset;
                damageText.transform.localScale = new Vector3(other.transform.localScale.x / 2, other.transform.localScale.x / 2, other.transform.localScale.x / 2);
                damageText.GetComponent<TextMesh>().text = attackpoint.ToString();
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
