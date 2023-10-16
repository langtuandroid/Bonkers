using System;
using UnityEngine;

using static UnityEngine.Mathf;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        Ctx.Animator.SetBool(Ctx.IsWalkingHash, true);
        //Ctx.Animator.SetBool(Ctx.IsRunningHash, false);
    }
    public override void ExitState() { }
    
    public override void UpdateState() 
    {
        CheckSwitchStates();
        
        // Ctx.AppliedMovementX = Ctx.CurrentMovementInput.x * Ctx.moveGroundMaxSpeed;
        // Ctx.AppliedMovementZ = Ctx.CurrentMovementInput.y * Ctx.moveGroundMaxSpeed;
    }

    public override void UpdateVelocity(ref Vector3 currentVelocity, Single deltaTime)
    {
        // Reorient source velocity on current ground slope (this is because we don't want our smoothing to cause any velocity losses in slope changes)
        currentVelocity = Ctx.Motor.GetDirectionTangentToSurface(direction: currentVelocity, surfaceNormal: Ctx.Motor.GroundingStatus.GroundNormal) * currentVelocity.magnitude;

        // Calculate target velocity
        Vector3 __inputRight      = Vector3.Cross(lhs: Ctx.CurrentMovementInput, rhs: Ctx.Motor.CharacterUp);
        Vector3 __reorientedInput = Vector3.Cross(lhs: Ctx.Motor.GroundingStatus.GroundNormal, rhs: __inputRight).normalized * Ctx.CurrentMovementInput.magnitude;
        Vector3 __targetMovementVelocity = __reorientedInput * Ctx.moveGroundMaxSpeed;

        // Smooth movement Velocity
        currentVelocity = Vector3.Lerp(a: currentVelocity, b: __targetMovementVelocity, t: 1f - Exp(power: -Ctx.moveGroundSharpness * deltaTime));
    }


    public override void InitialSubState() { }
    public override void CheckSwitchStates() 
    {
        if (!Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Idle());
        }
        // else if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
        // {
        //     SwitchState(Factory.Run());
        // }
    }
}
