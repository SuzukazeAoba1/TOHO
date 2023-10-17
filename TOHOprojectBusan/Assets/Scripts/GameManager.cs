using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private EnemySpawnController spawncontroller;

    public float camerasize;
    public Vector2 movingzone;
    public Vector2 deathzone;
    [Header("# 승리조건")]
    public float gameTime = 0;
    public float maxGameTime = 10f;
    [Header("# 페이즈 관리")]
    public float[] phasetimes;
    public Background[] backgrounds;
    public Backgroundaudio backgroundaudio;
    public int nextphase = 1;
    private bool canchange = true;
    [Header("# Game Object")]
    public PoolManager BulletPool;
    public PoolManager BarragePool;
    public PoolManager EnemyPool;
    public PoolManager GitaPool;
    public PoolManager EffectPool;
    public WeaponSpawn weaponSpawn;
    public UpgradeUI upgradeUI;
    public ContinueUI continueUI;
    public GameObject main_camera;
    [Header("# PlayerStats")]
    public GameObject player;
    public int level;
    public int exp;
    public int[] nextExp = { 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4 ,4,4,4,4,4,4,4,4,4,4,4,4,4};
    public bool isDead = false;
    public bool continued = false;
    void Start()
    {

        if (instance == null)
        {
            instance = this;

            DOTween.Init(true, true, LogBehaviour.Verbose);
            DOTween.SetTweensCapacity(5000, 500); //인게임에서 움직이는 객체 생성 최대 500개
            DOTween.defaultAutoKill = false;
            DOTween.defaultAutoPlay = AutoPlay.None;

            spawncontroller = GetComponent<EnemySpawnController>();
            spawncontroller.Init(movingzone);
        }
        else
        {
            Debug.LogWarning("이 씬에 게임 매니저가 두 개 존재합니다!");
            Destroy(gameObject);
        }
        level = 1;

        //다중 캐릭터 선택 넣을 경우 이걸 바꿔야됨.
        //레이무의 기본 무기 시작할때 지급(레이무 무기 버튼을 한번 누른 취급)

        upgradeUI.Select(0);
        DOTween.Init(true, true, LogBehaviour.Verbose);
        LeanTween.init(500);

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
        if (gameTime >= maxGameTime)
        {
            if(continued)
            {
                SceneManager.LoadScene("CVictory");
            }
            else
            {
                SceneManager.LoadScene("Victory");
            }
            
        }

        if (gameTime >= phasetimes[nextphase] && canchange)
        {
            canchange = false;
            if (backgrounds != null)
            {
                // Backgrounds 배열의 각 요소에 대해 반복
                foreach (Background background in backgrounds)
                {
                    // 각 Background 개체의 Change 함수 호출
                    if (background != null) // null 체크 추가
                    {
                        background.Backgroundchange(nextphase);
                    }
                }
            }

            backgroundaudio.Musicchange(nextphase);
            if(nextphase < phasetimes.Length-1)
            {
                canchange = true;
                nextphase++;
            }
            
        }
        //키보드 입력을 받으면 메인 화면 씬으로 전환
    }

    public void Die()
    {
        isDead = true;
        continueUI.Show();
    }
    public void GetExp(int nExp)
    {
        exp += nExp;
        //테이블에 없는 경험치부턴 무제한으로 늘어나게 함
        if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {

            exp -= nextExp[Mathf.Min(level, nextExp.Length - 1)];
            level++;
            upgradeUI.Show();
        }
    }


}
