using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIAudio : MonoBehaviour
{//will function as a singleton
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winLevelClip;
    [SerializeField] private AudioClip resetLevelClip;
    [SerializeField] private AudioClip failClip;



    public void PlayWinLevel()
    {
        audioSource.PlayOneShot(winLevelClip);
    }
    public void PlayResetLevel()
    {
        audioSource.PlayOneShot(resetLevelClip);
    }
    public void PlayFailLevel()
    {
        audioSource.PlayOneShot(failClip);
    }

}
