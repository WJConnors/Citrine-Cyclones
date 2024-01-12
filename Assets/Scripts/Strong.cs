using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Strong : BaseCharacter
{
    bool holding = false;
    GameObject heldObject;
    public float detectionRadius = 5f;
    [SerializeField] private Transform holdPosition; //a child object on the strong player
    [SerializeField] [Range(5f, 18f)]private float throwForce = 12f;
    protected override void Update()
    {
        base.Update();
        if (PickUpInput())
        {
            
            if (!holding)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
                foreach (Collider2D collider in colliders)
                {

                    var checkPickable = collider.gameObject.GetComponent<Pickable>();
                    if (!checkPickable)
                        return;

                    SetHeldObject(checkPickable.gameObject);
                    break;
                    
                }
            }
            else if (holding)
            {
                HandleThrow();
            }

        }
        else if (holding)
        {
            heldObject.transform.position = holdPosition.position;
        }

    }
    private void SetHeldObject(GameObject newGo)
    {
        heldObject = newGo.gameObject;
        holding = true;
    }

    private void HandleThrow()
    {
        
       if (heldObject == null)
        {
            Debug.Log("picked up obj doesnt exist");
            return;
        }

        heldObject.GetComponent<Pickable>().BeThrown(throwForce);
        holding = false;
        heldObject = null;
    }

    protected override float GetMoveInput()
    {
        return Input.GetAxis("HorizontalArrows");
    }

    protected override bool GetJumpInput()
    {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }

    bool PickUpInput()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position,  detectionRadius);
    }
}
