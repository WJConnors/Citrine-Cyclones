using UnityEngine;
using UnityEngine.Events;

public class ActivationButton : MonoBehaviour
{
    
    private const string PLAYER_TAG = "Player";
    public UnityEvent OnPlayerPressed;
    public UnityEvent OnPlayerReleased;



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {

            OnPlayerPressed?.Invoke();
        }        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            OnPlayerReleased?.Invoke();
        }
    }
}