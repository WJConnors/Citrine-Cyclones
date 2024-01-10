using UnityEngine;

public class ActivateChildrenButton : MonoBehaviour
{
    [SerializeField] private Ladder ladder; // The parent GameObject whose children will be affected
    private const string PLAYER_TAG = "Player";
    // Method to enable components in all children
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
           
            ladder.TurnOnLadder();
        }        
    }
}