using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayAnim : MonoBehaviour
{
    private Animator myAnim;
    private SpriteRenderer mySR;
    public int isright;
    private bool iswarning;
    // Start is called before the first frame update

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        mySR = GetComponent<SpriteRenderer>();
        isright = GetComponentInParent<SubwaySpawn>().leftright;

        switch(isright)
        {
            case 0:
                myAnim.SetBool("isRight", false);
                break;
            case 1:
                myAnim.SetBool("isRight", true);
                break;
            case 2:
                myAnim.SetBool("isRight", false);
                break;
            case 3:
                myAnim.SetBool("isRight", true);
                break;
        }
    }
    void Start()
    {
        
    }

    private void OnEnable()
    {
        iswarning = true;
        StartCoroutine(blink());
        myAnim.SetInteger("Sequence", 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator blink()
    {
        while (iswarning)
        {

            Color myC = mySR.color;
            yield return new WaitForSeconds(1.2f);
            Color blinkC = new Color(mySR.color.r / 2, mySR.color.g / 2, mySR.color.b / 2);
            LeanTween.value(gameObject, UpdateColor, mySR.color, blinkC, 0.9f)
                .setOnComplete(() =>
                {
                    LeanTween.value(gameObject, UpdateColor, blinkC, myC, 0.3f);
                });
            //yield return new WaitForSeconds(1.2f);
            
        }
    }

    void UpdateColor(Color color)
    {
        mySR.color = color;
    }
}
