using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    public List<SpriteRenderer> ladderSprites;
    private BoxCollider2D ladderCollider;
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

    public void TurnOnLadder()
    {
        ladderCollider.enabled = true;
        foreach (var sprite in ladderSprites)
        {
            sprite.enabled = true;
        }
    }
}
