using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrage : MonoBehaviour
{
    public GameObject Target;
    public GameObject myEnemy;
    public GameObject myGroup;

    public float HP;
    public float HP_now;

    public float Speed_now;
    public float Speed_base;
    public float Speed_add;

    public float m_delay;
    public float m_distance;

    public void ActiveTimerOn()
    {
        HP_now = HP;
        transform.SetParent(myGroup.transform);

        if (m_delay > 0.0f)
        {
            Invoke("ActivateSelf", m_delay);
        }
        else
        {
            ActivateSelf();
        }
    }
    
    private void ActivateSelf()
    {
        transform.localRotation = Quaternion.identity * transform.rotation;
        transform.localPosition = Vector3.zero;
        transform.Translate(0.1f * m_distance * Vector2.up);
        gameObject.SetActive(true);
    }

    public void SetData(GameObject enemy, GameObject group, GameObject player, float basespeed, float addspeed, float distance, float delay)
    {
        Target = player;
        myGroup = group;
        myEnemy = enemy;
        m_delay = delay;
        m_distance = distance;
        Speed_base = basespeed;
        Speed_now = basespeed;
        Speed_add = addspeed;
     }

    public float Pierce(float atk)
    {
        if(HP_now <= atk)
        {
            return 0;
        }
        else if(atk > HP_now)
        {
            return HP_now - atk;
        }
        else
        {
            return 0;
        }
            
    }
    public void Damage(float atk)
    {
        HP_now -= atk;

        if (HP_now <= 0)
        {
            Kill();
        }
    }
    void Update()
    {
        transform.Translate(Speed_now * Vector2.up * Time.deltaTime);

        if (HP_now <= 0)
        if (HP_now <= 0)
        {
            Kill();
        }
    }

    void FixedUpdate()
    {

        if(Speed_add > 0)
        {
            if (Speed_now < Speed_base + Speed_add)
            {
                Speed_now += Speed_add * Time.timeScale * 0.01f;
            }
        }
        else 
        {
            if (Speed_now > Speed_base + Speed_add)
            {
                Speed_now += Speed_add * Time.timeScale * 0.01f;
            }
        }

        
    }
    //private void ondestroy()
    //{
    //    gameobject exp = gamemanager.instance.gitapool.get(1);
    //    exp.transform.position = transform.position;
    //}

    public void Kill()
    {
        GameObject exp = GameManager.instance.GitaPool.Get(1);
        exp.transform.position = transform.position;

        Death();
    }

    public void Death()
    {
        transform.SetParent(GameManager.instance.BarragePool.transform);
        gameObject.SetActive(false);
        myGroup.GetComponent<EnemyBarrageGroup>().bulletcount--;
    }
}
