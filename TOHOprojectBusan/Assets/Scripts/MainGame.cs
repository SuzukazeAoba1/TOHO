using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //�÷��̾� �Է� ��� ��ȯ
        //�� ���� ��� �۵�
        //���� �ڵ� ���� ��� �۵�
    }

    /// <summary>
    /// ������ ������ �� �θ��� �Լ�, ������Ʈ ����� ����
    /// </summary>
    /// <param name="lbl"></param>
    public void GamePlay()
    {
        gameObject.GetComponent<EnemySpawnCotroller>().Play();

        //���� �ʱ�ȭ, ���� �÷��̾� ����
        //�� ���� ����ġ Ȱ��ȭ
        //���� ���� ���� ����ġ Ȱ��ȭ
    }

    /// <summary>
    /// ���� ������ ���߰� ���� ���� UI ȭ���� �Ѵ� �Լ�    
    /// </summary>
    /// <param name="lbl"></param>
    public void GameOver()
    {
 
    }

    /// <summary>
    /// ���� ������ ���߰� Ŭ���� UI ȭ�� �Ѵ� �Լ� 
    /// </summary>
    /// <param name="lbl"></param>
    public void GameClear()
    {
        
    }


}
