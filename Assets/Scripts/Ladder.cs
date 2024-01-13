using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ladder : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    public List<SpriteRenderer> ladderSprites;
    private BoxCollider2D ladderCollider;
    [HideInInspector]public UnityEvent OnLadderOn;
    [HideInInspector] public UnityEvent OnLadderOff;
    private void Awake()
    {
        ladderCollider = GetComponent<BoxCollider2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            collision.gameObject.GetComponent<BaseCharacter>().isClimbing = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            collision.gameObject.GetComponent<BaseCharacter>().isClimbing = false;
        }
    }
    [ProButton] //just for easy debugging 
    public void TurnOnLadder()
    {
        ladderCollider.enabled = true;
        foreach (var sprite in ladderSprites)
        {
            sprite.enabled = true;
        }
        OnLadderOn?.Invoke();
    }

    [ProButton]
    public void TurnOffLadder()
    {
        ladderCollider.enabled = false;
        foreach (var sprite in ladderSprites)
        {
            sprite.enabled = false;
        }
        OnLadderOff?.Invoke();
    }
}
