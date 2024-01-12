using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource playerAs;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private BaseCharacter baseChar;
    private void Awake()
    {
        baseChar.OnPlayerJump.AddListener(PlayJumpAudio);
    }
    public void PlayJumpAudio()
    {
        playerAs.PlayOneShot(jumpClip);
    }
}
