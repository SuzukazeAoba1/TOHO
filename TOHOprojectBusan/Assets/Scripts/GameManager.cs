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
            Debug.LogWarning("이 씬에 게임 매니저가 두 개 존재합니다!");
            Destroy(gameObject);
        }
        health = maxHealth;
        level = 1;

        //다중 캐릭터 선택 넣을 경우 이걸 바꿔야됨.
        //레이무의 기본 무기 시작할때 지급(레이무 무기 버튼을 한번 누른 취급)

        upgradeUI.Select(0);
        DOTween.Init(true, true, LogBehaviour.Verbose);

        Init();
        Title();
    }

    private void Init()
    {
        // 게임 리소스 로딩에 관한 스크립트
    }

    private void Title()
    {
        //게임 타이틀 UI 화면을 띄우고 키보드 입력을 받도록 설정
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (health <= 0)
        {
            Die();
        }
        //키보드 입력을 받으면 메인 화면 씬으로 전환
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
