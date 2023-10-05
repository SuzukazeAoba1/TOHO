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
            // ���� ���� ���ٸ� target�� null�� ����
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

        // target�� ���� ����� ���� �Ҵ�
        target = closestEnemy;
    }

    private void ShooTraget()
    {
        if (target != null)
        {
            // target ��ġ�� ���� ��ġ ������ ���� ���͸� ���մϴ�.
            Vector2 direction = (target.transform.position - transform.position).normalized;

            // ���� ���Ϳ� bulletspeed�� ���� �Ѿ˿� �����մϴ�.
            // ���⼭ X�� �������� �����̱� ���� direction.x�� ����մϴ�.
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