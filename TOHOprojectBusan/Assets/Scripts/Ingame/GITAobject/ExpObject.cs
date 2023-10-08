using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObject : MonoBehaviour
{
    public int EXP = 1;
    public float destroy_Time = 7f;
    public float addforce = 50f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("DeactivateSelf", destroy_Time);
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, addforce));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}
