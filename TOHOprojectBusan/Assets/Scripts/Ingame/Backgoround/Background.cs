using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //����� �����̴� �ӵ��� ����
    public float backgroundspeed = 10f;
    private Vector3 downVector = Vector3.down;
    public Transform removePoint;
    public Sprite[] bimages;
    private SpriteRenderer mySR;
    private Color originalcolor;
    //����� ������� ����(y��) ����
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
        //����� ����ؼ� �Ʒ��� ������
        transform.position += downVector * backgroundspeed * Time.deltaTime;
        float Yposition = transform.position.y;

        //����� ������ y�࿡ �ٴٸ� ��� spawnpoint�� �̵�
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
