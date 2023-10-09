using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumgiEffect : MonoBehaviour
{
    public float atk = 15f;
    private float attackpoint = 15f;
    private PolygonCollider2D myCL;
    public float effect_time = 0.2f;
    public float ready_time = 0.09f;
    private Animator myAnim;
    private GameObject damageText;
    private Vector3 offset = new Vector3(0, 1f, 0);
    // Start is called before the first frame update

    private void Awake()
    {
        myCL = GetComponent<PolygonCollider2D>();
        myAnim = GetComponent<Animator>();
        attackpoint = atk;
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
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().HP -= attackpoint;
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = other.transform.position + offset;
                damageText.transform.localScale = new Vector3(other.transform.localScale.x / 2, other.transform.localScale.x / 2, other.transform.localScale.x / 2);
                damageText.GetComponent<TextMesh>().text = attackpoint.ToString();
            }
            else if (other.gameObject.CompareTag("Barrage"))
            {

                other.gameObject.GetComponent<Barrage>().HP -= attackpoint;
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = transform.position + offset;
                damageText.transform.localScale = new Vector3(other.transform.localScale.x / 5, other.transform.localScale.x / 5, other.transform.localScale.x / 5);
                damageText.GetComponent<TextMesh>().text = attackpoint.ToString();

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
