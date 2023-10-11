using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrage : MonoBehaviour
{
    public GameObject myEnemy;
    public float HP;
    public float Speed_now;
    public float Speed_base;
    public float Speed_add;
    public float delay;

    public void ActiveTimerOn()
    {
        if (delay > 0.0f) Invoke("ActivateSelf", delay);
        else              gameObject.SetActive(true);
    }
    
    private void ActivateSelf()
    {
        transform.position = myEnemy.transform.position;
        gameObject.SetActive(true);
    }

    public void SetSpeed(float basespeed, float addspeed)
    {
        Speed_base = basespeed;
        Speed_now = basespeed;
        Speed_add = addspeed;
    }

    public float Pierce(float atk)
    {
        if(HP <= atk)
        {
            return 0;
        }
        else if(atk > HP)
        {
            return HP - atk;
        }
        else
        {
            return 0;
        }
            
    }
    public void Damage(float atk)
    {
        HP -= atk;

        if (HP <= 0)
        {
            Death();
        }
    }
    void Update()
    {

        transform.Translate(Speed_now * Vector2.up * Time.deltaTime);

        if (HP <= 0)
        {
            GameObject exp = GameManager.instance.GitaPool.Get(1);
            exp.transform.position = transform.position;
            transform.DOKill();
            Destroy(gameObject);
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

    public void Death()
    {
        GameObject exp = GameManager.instance.GitaPool.Get(1);
        exp.transform.position = transform.position;
        Destroy(gameObject);
    }

}
