using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundaudio : MonoBehaviour
{
    private AudioSource myAS;
    public AudioClip[] musics;
    public AudioClip middlemusic;
    // Start is called before the first frame update
    void Start()
    {
        myAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Musicchange(int i)
    {
        StartCoroutine(Playnewmusic());
        myAS.Stop();
        myAS.clip = middlemusic;
        myAS.Play();

        IEnumerator Playnewmusic()
        {
            yield return new WaitForSeconds(2.7f);
            myAS.Stop();
            myAS.clip = musics[i];
            myAS.Play();
        }
    }

}
