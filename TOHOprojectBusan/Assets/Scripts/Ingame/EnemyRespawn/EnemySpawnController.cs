using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 문서 데이터를 읽어와 몬스터 생성과 이동 패턴을 종합적으로 관리하는 클래스
/// </summary>
/// <param name="lbl"></param>
public class EnemySpawnController : MonoBehaviour
{
    public EnemySpawnContainer SpawnContainer;
    public EnemyContainer EnemyContainer;
    public EnemyMoveContainer MoveContainer;
    public EnemyMoveController MoveController;
    public EnemyBarrageContainer BarrageContainer;
    public EnemyBarrageController BarrageController;

    List<Dictionary<string, object>> sqawnpattendata;
    List<Dictionary<string, object>> movesequencedata;

    private EnemySpawner spawner;

    SpawnPatten spawnbuf;
    public float spawnTimer;
    public int spawnCounter;
    public float nextSpawnTime;

    public bool pause;
    public bool reset;

    public void Init(Vector2 movingzone)
    {
        movesequencedata = new List<Dictionary<string, object>>();
        sqawnpattendata = new List<Dictionary<string, object>>();

        spawner = gameObject.GetComponent<EnemySpawner>();
        spawner.SetContainer(EnemyContainer);
        spawner.SetMoveController(MoveController);
        spawner.SetZonePos(movingzone);

        MoveController.SetContainer(MoveContainer);
        MoveController.SetZonePos(movingzone);
        BarrageController.SetContainer(BarrageContainer);

        sqawnpattendata.Clear();
        movesequencedata.Clear();

        movesequencedata = CSVReader.Read("move_sequence_data");
        sqawnpattendata = CSVReader.Read("spawn_patten_data");

        MoveContainer.SetFileData(movesequencedata);
        SpawnContainer.SetFileData(sqawnpattendata);

        pause = true;
        reset = false;
    }

    public void Play()
    {
        spawnCounter = 0;
        spawnTimer = 0.0f;
        nextSpawnTime = 0.0f;
        pause = false;
    }

    void Update()
    {
        if(reset)
        {
            Play();
            reset = false;
        }

        if (!pause)
        {
            spawnTimer += Time.deltaTime * 10.0f;

            spawnbuf = SpawnContainer.SpawnContainer[spawnCounter]; //정보를 가져옴
            nextSpawnTime = spawnbuf.m_spawntime;

            if (spawnTimer >= nextSpawnTime && spawnCounter < SpawnContainer.SpawnContainer.Count) //
            {
                spawner.Spawn(spawnbuf.m_spawnposid, spawnbuf.m_enemyid, spawnbuf.m_movesequenceid, spawnbuf.m_spawnfilp); 
                spawnCounter += 1;
                //BarrageController.Shoot(transform, false);
            }
        }
    }

    public void Pause()
    {
        pause = true;
    }

    public void PauseCancel()
    {
        pause = false;
    }



}
