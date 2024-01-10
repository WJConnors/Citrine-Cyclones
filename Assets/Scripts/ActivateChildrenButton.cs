using UnityEngine;

public class ActivateChildrenButton : MonoBehaviour
{
    public GameObject parentObject; // The parent GameObject whose children will be affected

    // Method to enable components in all children
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Transform child in parentObject.transform)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                BoxCollider2D boxCollider = child.GetComponent<BoxCollider2D>();

                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = true;
                }

                if (boxCollider != null)
                {
                    boxCollider.enabled = true;
                }
            }
        }        
    }
}