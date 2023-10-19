using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawnController : MonoBehaviour
{
    private EnemyMoveContainer MoveContainer;
    private EnemyMoveController MoveController;
    private EnemySpawner spawner;

    [Range(0, 120)]
    public int spawnpos = 0;
    [Range(0.1f, 5.0f)]
    public float spawninterval = 0.5f;
    public bool spawnfilp = false;

    public GameObject[] TestEnemy;
    public GameObject[] TestBarrage;


    private void Start()
    {
        Init(new Vector2(22, 30));
    }

    private void OnEnable()
    {
        Play();
    }

    public void Init(Vector2 movingzone)
    {
        
        MoveContainer = gameObject.AddComponent<EnemyMoveContainer>();
        MoveController = gameObject.AddComponent<EnemyMoveController>();
        spawner = gameObject.AddComponent<EnemySpawner>();

        MoveContainer.SetTestData();

        MoveController.SetContainer(MoveContainer);
        MoveController.SetZonePos(movingzone);
 
        spawner.SetTestController(this);
        spawner.SetMoveController(MoveController);
        spawner.SetZonePos(movingzone);
  
    }

    public void Play()
    {
        if (TestEnemy[0] != null)
        {
            TestPlay();
        }
    }

    public void TestPlay()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.1f);
        spawner.TestSpawn(spawnpos, 0, 0, spawnfilp);
        yield return new WaitForSeconds(spawninterval);
        StartCoroutine(Respawn());
    }
}
