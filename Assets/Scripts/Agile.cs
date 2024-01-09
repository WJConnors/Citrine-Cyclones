using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agile : BaseCharacter
{
    bool doubleJump = true;
    protected override void Update()
    {
        base.Update();
        if (base.isGrounded)
        {
            doubleJump = true;
        }
        else
        {
            if (doubleJump && GetJumpInput())
            {
                base.Jump();
                doubleJump = false;
            }
        }
    }
    protected override float GetMoveInput()
    {
        return Input.GetAxis("HorizontalWASD");
    }
    protected override bool GetJumpInput()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
}
