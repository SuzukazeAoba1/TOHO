using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwaySpawn : MonoBehaviour
{
    public int leftright = 0;
    public float rightmax = 30;
    public float leftmax = 210;
    public float destroy_time = 6.6f;
    private SpriteRenderer[] spriteRenderers;
    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {
        switch (leftright)
        {
            case 0:
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(rightmax, rightmax - 60f));
                for (int i = 0; i < spriteRenderers.Length; i++)
                {
                    spriteRenderers[i].flipY = false;
                }
                break;
            case 1:
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(leftmax, leftmax - 60f));
                for (int i = 0; i < spriteRenderers.Length; i++)
                {
                    spriteRenderers[i].flipY = true;
                    spriteRenderers[i].flipX = true;
                }
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                for (int i = 0; i < spriteRenderers.Length; i++)
                {
                    spriteRenderers[i].flipY = false;
                }
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                for (int i = 0; i < spriteRenderers.Length; i++)
                {
                    spriteRenderers[i].flipY = true;
                    spriteRenderers[i].flipX = true;
                }
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0, 0, -90);
                for (int i = 0; i < spriteRenderers.Length; i++)
                {
                    spriteRenderers[i].flipY = false;
                    spriteRenderers[i].flipX = false;
                }
                break;
        }
        Destroy(gameObject, destroy_time);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
