using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //배경이 움직이는 속도를 선언
    public float backgroundspeed = 10f;
    private Vector3 downVector = Vector3.down;
    public Transform removePoint;
    public Sprite[] bimages;
    private SpriteRenderer mySR;
    private Color originalcolor;
    //배경이 사라지는 지점(y축) 지정
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        originalcolor = mySR.color;
    }

    // Update is called once per frame
    void Update()
    {
        //배경이 계속해서 아래로 움직임
        transform.position += downVector * backgroundspeed * Time.deltaTime;
        float Yposition = transform.position.y;

        //배경이 설정한 y축에 다다를 경우 spawnpoint로 이동
        if (transform.position.y < removePoint.position.y)
        {
            transform.position = spawnPoint.position;
        }
    }

    public void Backgroundchange(int i)
    {
        Color bcolor = new Color(0, 0, 0);

        LeanTween.value(mySR.gameObject, UpdateColor, mySR.color, bcolor, 2f)
            .setOnComplete(() =>
            {
                mySR.sprite = bimages[i];
                LeanTween.value(mySR.gameObject, UpdateColor, mySR.color, originalcolor, 2f);



            });

    }
    void UpdateColor(Color color)
    {
        mySR.color = color;
    }
}
