using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UMYANGOK : MonoBehaviour
{
    public WeaponUpgrade grandparent;
    public WeaponData parentWeaponData;
    public float ATK;
    private float attackpoint = 7;
    public int effectID = 4;
    private int eID = 3;
    private AudioSource myAS;
    public float Cooltime;

    public float destroy_Time;
    private GameObject damageText;
    private GameObject effect;
    private float bulletspeed;
    private float candamage = 0;
    public float offset = 0.7f;

    // Start is called before the first frame update

    private void Awake()
    {
        myAS = GetComponent<AudioSource>();
        Transform parent = transform.parent;
        grandparent = parent.GetComponentInParent<WeaponUpgrade>();
        parentWeaponData = grandparent.weapon;
    }
    void Start()
    {
        eID = effectID - 1;
        attackpoint = ATK;
        Player playerscript = FindObjectOfType<Player>();

        if (playerscript != null)
        {
            bulletspeed = playerscript.bulletspeed;
        }
        else
        {
            bulletspeed = 0f;
        }
    }

    private void OnEnable()
    {
        ATK = parentWeaponData.ATK[grandparent.currentlevel - 1] - 1f;
        attackpoint = parentWeaponData.ATK[grandparent.currentlevel - 1] - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        candamage -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Color eC = other.GetComponent<SpriteRenderer>().color;
        if (candamage <= 0f)
        {
            candamage = Cooltime;
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
            {
                myAS.Play();
                Color othercolor = other.gameObject.GetComponent<SpriteRenderer>().color;
                other.gameObject.GetComponent<SpriteRenderer>().color = new Color(othercolor.r / 3, othercolor.g / 3, othercolor.b / 3);
                other.gameObject.GetComponent<Enemy>().isdamaged = true;
                Vector3 ePosition = other.ClosestPoint(transform.position);
                ePosition.y += 1f;
                effect = GameManager.instance.EffectPool.Get(eID);
                effect.transform.position = other.ClosestPoint(transform.position);
                ePosition.y += offset;
                other.gameObject.GetComponent<Enemy>().Damage(attackpoint);
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = other.ClosestPoint(transform.position);
                //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 4f, other.transform.localScale.y / 4f, other.transform.localScale.z / 4f);
                damageText.GetComponent<TextMeshPro>().text = attackpoint.ToString();
            }
            else if (other.gameObject.CompareTag("Barrage"))
            {
                myAS.Play();
                Vector3 ePosition = other.ClosestPoint(transform.position);
                ePosition.y += offset;
                effect = GameManager.instance.EffectPool.Get(eID);
                other.gameObject.GetComponent<Barrage>().Damage(attackpoint);
                effect.transform.position = other.ClosestPoint(transform.position);
                damageText = GameManager.instance.GitaPool.Get(0);
                damageText.transform.position = other.ClosestPoint(transform.position);
                //damageText.transform.localScale = new Vector3(other.transform.localScale.x / 6f, other.transform.localScale.y / 6f, other.transform.localScale.z / 6f);
                damageText.GetComponent<TextMeshPro>().text = attackpoint.ToString();

            }
        }
    }
}
