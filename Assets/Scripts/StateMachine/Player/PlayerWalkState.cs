using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{

    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }

    public override void EnterState() {

        Debug.Log("WALKING STATE");

        /*
        Animator Setup

        _ctx.Animator.SetBool(_ctx.IsWalkingHash, true);
        _ctx.Animator.SetBool(_ctx.IsRunningHash, false);

        */

    }

    public override void UpdateState() {

        CheckSwitchStates();

        Ctx.PlayerMovementX = Ctx.MoveDirectionX * Ctx.MoveSpeed;
        Ctx.PlayerMovementZ = Ctx.MoveDirectionZ * Ctx.MoveSpeed;

        Quaternion targetRotation = Quaternion.LookRotation(Ctx.TargetDirection);
        Ctx.TransformRotation = Quaternion.Slerp(Ctx.CurrentRotation, targetRotation, Ctx.RotationSpeed * Time.deltaTime);
    }

    public override void ExitState() { }

    public override void CheckSwitchStates() {

        if (!Ctx.IsMoving)
        {

            SwitchState(Factory.Idle());

        }
        else if (Ctx.IsMoving && Ctx.IsRunning) {

            SwitchState(Factory.Run());
        
        }
    
    
    }

    public override void InitializeSubState() { }

}
