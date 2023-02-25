using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameMusic;

    private void Awake()
    {
  
    }
    public void StartGame()
    {
        transform.localScale = Vector3.zero;
        Time.timeScale = 1f;

        if(audioSource && gameMusic)
        {
            audioSource.clip = gameMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
