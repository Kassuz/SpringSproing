using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour
{

    AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        //source.PlayDelayed(1.2f);
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1.2f);
        source.Play();
        
    }
}
