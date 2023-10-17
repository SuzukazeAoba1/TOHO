using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KogasaHit : MonoBehaviour
{
    [Header("# 스테이터스")]
    public float hp;
    private float health = 7;
    public int effectID = 4;
    private int eID = 5;
    
    public float Cooltime;

    public float destroy_Time;
    private GameObject damageText;
    private GameObject effect;
    public float offset = 0.7f;
    [Header("#이건 체력바")]
    public Slider hpslider;
    public GameObject canvas;
    private float hpposition = -1.28f;

    RectTransform hpBar;

    // Start is called before the first frame update

    private void Awake()
    {
        canvas = GameObject.Find("ObjectCanvas");
    }
    void Start()
    {
        hpBar = Instantiate(hpslider, canvas.transform).GetComponent<RectTransform>();
        eID = effectID - 1;
        health = hp;
        Player playerscript = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _hpsliderPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + hpposition, 0));
        hpBar.position = _hpsliderPos;
        hpBar.gameObject.GetComponent<Slider>().value = health / hp;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Barrage"))
        {
            effect = GameManager.instance.EffectPool.Get(eID);
            Vector3 ePosition = other.ClosestPoint(transform.position);
            ePosition.y += offset;
            damageText = GameManager.instance.GitaPool.Get(0);
            damageText.transform.position = other.ClosestPoint(transform.position);
            effect.transform.position = other.ClosestPoint(transform.position);
            effect = GameManager.instance.EffectPool.Get(eID);
            health -= other.gameObject.GetComponent<Barrage>().HP;
            damageText.GetComponent<TextMeshPro>().text = other.gameObject.GetComponent<Barrage>().HP.ToString();
            other.gameObject.GetComponent<Barrage>().Kill();
            //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 6f, other.transform.localScale.y / 6f, other.transform.localScale.z / 6f);
            

        }
    }

    private void OnDestroy()
    {
    }
}