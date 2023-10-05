using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private EnemySpawnCotroller spawner;

    public float camerasize;
    public Vector2 movingzone;
    public Vector2 deathzone;

    void Start()
    {
        spawner = GetComponent<EnemySpawnCotroller>();
        spawner.Init(movingzone);
        spawner.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어 입력 기능 전환
        //맵 루프 기능 작동
        //몬스터 자동 생성 기능 작동
    }

    /// <summary>
    /// 게임이 시작할 때 부르는 함수, 업데이트 기능을 깨움
    /// </summary>
    /// <param name="lbl"></param>
    public void GamePlay()
    {
        

        //스탯 초기화, 게임 플레이어 생성
        //맵 루프 스위치 활성화
        //몬스터 생성 패턴 스위치 활성화
    }

    /// <summary>
    /// 게임 진행을 멈추고 게임 오버 UI 화면을 켜는 함수    
    /// </summary>
    /// <param name="lbl"></param>
    public void GameOver()
    {
 
    }

    /// <summary>
    /// 게임 진행을 멈추고 클리어 UI 화면 켜는 함수 
    /// </summary>
    /// <param name="lbl"></param>
    public void GameClear()
    {
        
    }


}
