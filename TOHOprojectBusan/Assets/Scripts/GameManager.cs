using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private EnemySpawnController spawncontroller;

    public float camerasize;
    public Vector2 movingzone;
    public Vector2 deathzone;
    [Header("# Game Object")]
    public float gameTime = 0;
    public float maxGameTime = 6 * 60;
    [Header("# Game Object")]
    public PoolManager BulletPool;
    public PoolManager BarragePool;
    public PoolManager EnemyPool;
    public PoolManager GitaPool;
    public PoolManager EffectPool;
    public WeaponSpawn weaponSpawn;
    public UpgradeUI upgradeUI;
    [Header("# PlayerStats")]
    public int health;
    public int maxHealth = 5;
    public int level;
    public int exp;
    public int[] nextExp = { 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4 ,4,4,4,4,4,4,4,4,4,4,4,4,4};
    public bool isDead = false;
    void Start()
    {

        if (instance == null)
        {
            instance = this;

            DOTween.Init(true, true, LogBehaviour.Verbose);
            DOTween.SetTweensCapacity(5000, 500); //�ΰ��ӿ��� �����̴� ��ü ���� �ִ� 500��
            DOTween.defaultAutoKill = false;
            DOTween.defaultAutoPlay = AutoPlay.None;

            spawncontroller = GetComponent<EnemySpawnController>();
            spawncontroller.Init(movingzone);
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
        //���̺� ���� ����ġ���� ���������� �þ�� ��
        if(exp >= nextExp[Mathf.Min(level, nextExp.Length-1)])
        {
            
            exp -= nextExp[Mathf.Min(level, nextExp.Length - 1)];
            level++;
            upgradeUI.Show();
        }
    }

}
