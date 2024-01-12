using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderAudio : MonoBehaviour
{

    [SerializeField] private AudioSource ladderAudioSource;
    [SerializeField] private AudioClip ladderAudioLoop;
    [SerializeField] private Ladder ladder;
    private void Start()
    {
        ladderAudioSource = GetComponent<AudioSource>();
        ladder.OnLadderOn.AddListener(PlayLadderAudio);
        ladder.OnLadderOff.AddListener(StopLadderAudio);
    }


    public void PlayLadderAudio()
    {
        ladderAudioSource.Play();
    }
    public void StopLadderAudio()
    {
        ladderAudioSource.Stop();
    }
}
