using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Object")]
    public float gameTime = 0;
    public float maxGameTime = 6 * 60;
    [Header("# Game Object")]
    public PoolManager BulletPool;
    public PoolManager BarragePool;
    public PoolManager EnemyPool;
    public PoolManager GitaPool;
    public WeaponSpawn weaponSpawn;
    public UpgradeUI upgradeUI;
    [Header("# PlayerStats")]
    public int health;
    public int maxHealth = 5;
    public int level;
    public int exp;
    public int[] nextExp = { 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4 };
    public bool isDead = false;
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("�� ���� ���� �Ŵ����� �� �� �����մϴ�!");
            Destroy(gameObject);
        }
        health = maxHealth;
        level = 1;

        //���� ĳ���� ���� ���� ��� �̰� �ٲ�ߵ�.
        //���̹��� �⺻ ���� �����Ҷ� ����(���̹� ���� ��ư�� �ѹ� ���� ���)

        upgradeUI.Select(0);
        DOTween.Init(true, true, LogBehaviour.Verbose);

        Init();
        Title();
    }

    private void Init()
    {
        // ���� ���ҽ� �ε��� ���� ��ũ��Ʈ
    }

    private void Title()
    {
        //���� Ÿ��Ʋ UI ȭ���� ���� Ű���� �Է��� �޵��� ����
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (health <= 0)
        {
            Die();
        }
        //Ű���� �Է��� ������ ���� ȭ�� ������ ��ȯ
    }

    public void Die()
    {
        isDead = true;
    }
    public void GetExp(int nExp)
    {
        exp += nExp;

        if(exp >= nextExp[level-1])
        {
            
            exp -= nextExp[level - 1];
            level++;
            upgradeUI.Show();
        }
    }

}
