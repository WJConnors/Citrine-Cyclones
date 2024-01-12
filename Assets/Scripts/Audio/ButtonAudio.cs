using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioSource buttonAudioSource;
    [SerializeField] private AudioClip buttonPressClip;
    [SerializeField] private AudioClip buttonReleaseClip;
    [SerializeField] private ActivationButton actButt;
    private void Awake()
    {
        actButt.OnPlayerPressed.AddListener(PlayPressedAudio);
        actButt.OnPlayerReleased.AddListener(PlayReleasedAudio);
    }
    public void PlayPressedAudio()
    {
        buttonAudioSource.PlayOneShot(buttonPressClip);
    }

    public void PlayReleasedAudio()
    {
        buttonAudioSource.PlayOneShot(buttonReleaseClip);
    }
}
