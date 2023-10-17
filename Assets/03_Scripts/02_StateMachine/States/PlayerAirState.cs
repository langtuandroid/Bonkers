﻿using UnityEngine;

public sealed class PlayerAirState : PlayerBaseState
{
    public PlayerAirState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) 
        : base(currentContext, playerStateFactory) 
    {
        IsRootState = true;
        SetSubState(Factory.Falling());
        SetSubState(Factory.Rising());
    }

    public override void EnterState() 
    {
        Debug.Log("Entering Air State");
        //Ctx.CurrentMovementY = Ctx.Gravity;
        //Ctx.AppliedMovementY = Ctx.Gravity;
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Air State");
    }
    
    public override void UpdateState(ref Vector3 currentVelocity, float deltaTime) 
    {
        // bool __isFalling = Ctx.CurrentMovementY <= 0.0f || !Ctx.IsJumpPressed;
        //
        // const Single FALL_MULTIPLIER = 2.0f;
        //
        // float __previousYVelocity = Ctx.CurrentMovementY;
        //
        // if (__isFalling)
        // {
        //     Ctx.CurrentMovementY += (Ctx.Gravity * FALL_MULTIPLIER * Time.deltaTime);
        //     Ctx.AppliedMovementY =  Max((__previousYVelocity + Ctx.CurrentMovementY) * .5f, -20.0f);
        //
        // }
        // else
        // {
        //     Ctx.CurrentMovementY += (Ctx.Gravity * Time.deltaTime);
        //     Ctx.AppliedMovementY =  (__previousYVelocity + Ctx.CurrentMovementY) * .5f;
        // }
    }
    
    public override void CheckSwitchStates() 
    {
        if(Ctx.Motor.GroundingStatus.IsStableOnGround)
        {
            SwitchState(Factory.Grounded());
        }
        // else
        // {
        //     if (Ctx.IsFalling)
        //     {
        //         SwitchState(Factory.Falling());
        //     }
        //     else
        //     {
        //         SwitchState(Factory.Rising());
        //     }
        // }
    }
}