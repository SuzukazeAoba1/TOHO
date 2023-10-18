using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayAnim : MonoBehaviour
{
    private Animator myAnim;
    private SpriteRenderer mySR;
    public int isright;
    private bool iswarning;
    public float warningtime = 3.6f;
    public float cometime = 0.3f;
    public float goingtime = 2.1f;
    private AudioSource myAudio;
    public AudioClip warning_sound;
    public AudioClip running_sound;
    // Start is called before the first frame update

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
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
        myAudio.clip = warning_sound;
        iswarning = true;
        myAudio.Play();
        StartCoroutine(Blink());
        StartCoroutine(Seaqunce1());
        StartCoroutine(Seaqunce2());
        StartCoroutine(Seaqunce3());
        myAnim.SetInteger("Sequence", 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Blink()
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

    IEnumerator Seaqunce1()
    {

        yield return new WaitForSeconds(warningtime);
        iswarning = false;
        LeanTween.cancel(gameObject);
        myAudio.clip = running_sound;
        myAudio.Play();
        myAnim.SetInteger("Sequence", 1);

    }

    IEnumerator Seaqunce2()
    {
        yield return new WaitForSeconds(warningtime + cometime);
        myAnim.SetInteger("Sequence", 2);
    }

    IEnumerator Seaqunce3()
    {
        yield return new WaitForSeconds(warningtime + cometime + goingtime);
        myAnim.SetInteger("Sequence", 3);
    }
    void UpdateColor(Color color)
    {
        mySR.color = color;
    }
}
