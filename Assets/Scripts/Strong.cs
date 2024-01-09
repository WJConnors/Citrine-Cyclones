using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Strong : BaseCharacter
{
    bool holding = false;
    GameObject heldObject;
    public float detectionRadius = 5f;
    Vector2 holdPosition = new(1f, 1f);
    public float throwForce = 12f;
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
                    if (collider.gameObject.GetComponent<Pickable>() != null)
                    {
                        heldObject = collider.gameObject;
                        holding = true;
                        break;
                    }
                }
            }
            else if (holding)
            {
                heldObject.GetComponent<Rigidbody2D>().velocity = new Vector2(heldObject.GetComponent<Pickable>().speed, throwForce);
                holding = false;
                heldObject = null;
            }

        }
        else if (holding)
        {
            heldObject.transform.position = transform.position + (Vector3)holdPosition;
        }

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
}
