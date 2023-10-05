using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    private GameObject target;
    public GameObject bullet;
    public float bulletspeed = 200f;
    private float shoottimer = 0f;
    public Transform ShootPoint;
    public float cooltime = 0.15f;

    void Update()
    {
        FindClosestEnemy();
        shoottimer -= Time.deltaTime;

        if (target != null && shoottimer <= 0f)
        {
            ShooTraget();
            shoottimer = cooltime;
        }
        else if (shoottimer <= 0)
        {
            JustShoot();
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            // 만약 적이 없다면 target은 null로 설정
            target = null;
            return;
        }

        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            Vector3 directionToEnemy = enemy.transform.position - currentPosition;
            float distanceToEnemy = directionToEnemy.sqrMagnitude;

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        // target에 가장 가까운 적을 할당
        target = closestEnemy;
    }

    private void ShooTraget()
    {
        if (target != null)
        {
            // target 위치와 현재 위치 사이의 방향 벡터를 구합니다.
            Vector2 direction = (target.transform.position - transform.position).normalized;

            // 방향 벡터에 bulletspeed를 곱해 총알에 적용합니다.
            // 여기서 X축 방향으로 움직이기 위해 direction.x를 사용합니다.
            GameObject newDollBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
            newDollBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x * bulletspeed, direction.y * bulletspeed));
        }
    }

    private void JustShoot()
    {
        GameObject newDollBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
        newDollBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed));
    }
}