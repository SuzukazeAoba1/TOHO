using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator myAnim;
    private bool isLeft;
    private bool isRight;
    private bool noMove = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        isLeft = true;
        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("Left", noMove);
        myAnim.SetBool("Right", noMove);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myAnim.SetBool("Left", isLeft);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myAnim.SetBool("Right", isRight);
        }
    }
}
