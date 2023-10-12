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

    public EnemyMoveController MoveController;
    public EnemyMoveContainer MoveContainer;

    public EnemyBarrageContainer BarrageSequence;
    public EnemyBarragePatten BarragePatten;
    public BarrageContainer BarrageList;

    List<Dictionary<string, object>> sqawnpattendata;
    List<Dictionary<string, object>> movesequencedata;
    List<Dictionary<string, object>> barragesquencedata;
    List<Dictionary<string, object>> barragepattendata;

    private EnemySpawner spawner;

    SpawnPatten spawnbuf;
    public float spawnTimer;
    public int spawnCounter;
    public float nextSpawnTime;
    public int testbarragepatten = 0;

    public bool pause;
    public bool reset;

    public void Init(Vector2 movingzone)
    {
        
        sqawnpattendata = new List<Dictionary<string, object>>();
        movesequencedata = new List<Dictionary<string, object>>();
        barragesquencedata = new List<Dictionary<string, object>>();
        barragepattendata = new List<Dictionary<string, object>>();


        spawner = gameObject.GetComponent<EnemySpawner>();
        spawner.SetContainer(EnemyContainer);
        spawner.SetMoveController(MoveController);
        spawner.SetZonePos(movingzone);

        MoveController.SetContainer(MoveContainer);
        MoveController.SetZonePos(movingzone);

        sqawnpattendata.Clear();
        movesequencedata.Clear();
        barragesquencedata.Clear();
        barragepattendata.Clear();

        sqawnpattendata = CSVReader.Read("main_spawn_data");
        movesequencedata = CSVReader.Read("move_sequence_data");
        barragesquencedata = CSVReader.Read("barrage_sequence_data");
        barragepattendata = CSVReader.Read("barrage_patten_data");

        SpawnContainer.SetFileData(sqawnpattendata);
        MoveContainer.SetFileData(movesequencedata);
        BarrageSequence.SetFileData(barragesquencedata);
        BarragePatten.SetFileData(barragepattendata);

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
            if (spawnCounter < SpawnContainer.SpawnContainer.Count)
            {
                spawnTimer += Time.deltaTime * 10.0f;
                spawnbuf = SpawnContainer.SpawnContainer[spawnCounter]; //현재의 오브젝트 정보를 가져옴
                nextSpawnTime = spawnbuf.m_spawntime;                   //현재 오브젝트가 스폰 되어야 할 시간

                if (nextSpawnTime < spawnTimer)
                {
                    GameObject buf = spawner.Spawn(spawnbuf.m_spawnposid, spawnbuf.m_enemyid, spawnbuf.m_movesequenceid, spawnbuf.m_spawnfilp);
                    buf.GetComponent<Enemy>().SetBarrageSetting(BarrageList, BarrageSequence.List[0], BarragePatten.List[testbarragepatten], spawnbuf.m_spawnfilp);
                    spawnCounter += 1;
                }
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
