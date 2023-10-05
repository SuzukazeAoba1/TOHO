using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //����� �����̴� �ӵ��� ����
    public float backgroundspeed = 10f;
    private Vector3 downVector = Vector3.down;
    public Transform removePoint;
    //����� ������� ����(y��) ����
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����� ����ؼ� �Ʒ��� ������
        transform.position += downVector * backgroundspeed * Time.deltaTime;
        float Yposition = transform.position.y;

        //����� ������ y�࿡ �ٴٸ� ��� spawnpoint�� �̵�
        if (transform.position.y < removePoint.position.y)
        {
            transform.position = spawnPoint.position;
        }
    }
}
