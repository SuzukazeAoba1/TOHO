using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        //키보드 입력을 받으면 메인 화면 씬으로 전환
    }

}
