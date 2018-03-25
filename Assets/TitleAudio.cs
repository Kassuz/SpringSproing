using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAudio : MonoBehaviour
{
    public GameObject menu;
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
        menu.SetActive(true);
    }
}
