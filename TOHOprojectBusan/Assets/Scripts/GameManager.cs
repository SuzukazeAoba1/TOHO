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
    [Header("# �¸�����")]
    public float gameTime = 0;
    public float maxGameTime = 10f;
    [Header("# ������ ����")]
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
        level = 1;

        //���� ĳ���� ���� ���� ��� �̰� �ٲ�ߵ�.
        //���̹��� �⺻ ���� �����Ҷ� ����(���̹� ���� ��ư�� �ѹ� ���� ���)

        upgradeUI.Select(0);
        DOTween.Init(true, true, LogBehaviour.Verbose);
        LeanTween.init(500);

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
                // Backgrounds �迭�� �� ��ҿ� ���� �ݺ�
                foreach (Background background in backgrounds)
                {
                    // �� Background ��ü�� Change �Լ� ȣ��
                    if (background != null) // null üũ �߰�
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
        //Ű���� �Է��� ������ ���� ȭ�� ������ ��ȯ
    }

    public void Die()
    {
        isDead = true;
        continueUI.Show();
    }
    public void GetExp(int nExp)
    {
        exp += nExp;
        //���̺� ���� ����ġ���� ���������� �þ�� ��
        if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {

            exp -= nextExp[Mathf.Min(level, nextExp.Length - 1)];
            level++;
            upgradeUI.Show();
        }
    }


}
